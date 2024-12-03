#include <SFML/Graphics.hpp>  
#include <cmath>               
#include <ctime>               
#include <cstdlib>             
#include <filesystem>          
#include <vector>              
#include <algorithm>           
#include <chrono>              // Used for timing operations (e.g., high_resolution_clock)
#include <thread>              // Provides support for multithreading
#include <iostream>            // For input/output streams (e.g., std::cout)
#include <mutex>               // Synchronization primitives to prevent race conditions
#include <omp.h>               // OpenMP header for parallel processing

#define STB_IMAGE_IMPLEMENTATION
#include <stb_image.h>         // Library for loading image files (stb_image.h)

namespace fs = std::filesystem; // Alias for the filesystem namespace


////////////////////////////
// UNEDITED FUNCTIONS
// /////////////////////////


// Helper structure for RGBA pixels
struct rgba_t
{
    uint8_t r; // Red component
    uint8_t g; // Green component
    uint8_t b; // Blue component
    uint8_t a; // Alpha (transparency) component
};

// Function to load an image as RGBA and return it as a vector of rgba_t
std::vector<rgba_t> load_rgb(const char* filename, int& width, int& height)
{
    int n; // Variable to store the number of channels in the image
    unsigned char* data = stbi_load(filename, &width, &height, &n, 4); // Load image data
    const rgba_t* rgbadata = (rgba_t*)(data); // Cast data to rgba_t type
    std::vector<rgba_t> vec; // Create a vector to hold the pixel data
    vec.assign(rgbadata, rgbadata + width * height); // Assign pixel data to the vector
    stbi_image_free(data); // Free the image data from memory
    return vec; // Return the vector of pixel data
}

// Function to calculate the color temperature of a single RGBA pixel
double rgbToColorTemperature(rgba_t rgba)
{
    double red = rgba.r / 255.0;   // Normalize red channel
    double green = rgba.g / 255.0; // Normalize green channel
    double blue = rgba.b / 255.0;  // Normalize blue channel

    // Adjust gamma correction for red, green, and blue
    red = (red > 0.04045) ? pow((red + 0.055) / 1.055, 2.4) : (red / 12.92);
    green = (green > 0.04045) ? pow((green + 0.055) / 1.055, 2.4) : (green / 12.92);
    blue = (blue > 0.04045) ? pow((blue + 0.055) / 1.055, 2.4) : (blue / 12.92);

    // Calculate XYZ color space values
    double X = red * 0.4124 + green * 0.3576 + blue * 0.1805;
    double Y = red * 0.2126 + green * 0.7152 + blue * 0.0722;
    double Z = red * 0.0193 + green * 0.1192 + blue * 0.9505;

    // Calculate chromaticity coordinates
    double x = X / (X + Y + Z);
    double y = Y / (X + Y + Z);

    // Calculate correlated color temperature (CCT) using McCamy's formula
    double n = (x - 0.3320) / (0.1858 - y);
    double CCT = 449.0 * n * n * n + 3525.0 * n * n + 6823.3 * n + 5520.33;

    return CCT; // Return the calculated color temperature
}

// Function to calculate sprite scale for displaying images
sf::Vector2f SpriteScaleFromDimensions(const sf::Vector2u& textureSize, int screenWidth, int screenHeight)
{
    float scaleX = screenWidth / float(textureSize.x); // Calculate scaling factor for width
    float scaleY = screenHeight / float(textureSize.y); // Calculate scaling factor for height

    // Return the smaller scaling factor to maintain the image's aspect ratio
    return sf::Vector2f(std::min(scaleX, scaleY), std::min(scaleX, scaleY));
}

///////////////////////////
// EDITED FUNCTIONS
//////////////////////////


// Function to calculate the median color temperature of an image
double filename_to_median(const std::string& filename)
{
    int width, height; // Variables to hold image dimensions
    auto rgbadata = load_rgb(filename.c_str(), width, height); // Load image data

    std::vector<double> temperatures(rgbadata.size()); // Create a vector to store temperatures

    // ParalleliSe the loop to calculate color temperatures for each pixel using OpenMP
#pragma omp parallel for
    for (size_t i = 0; i < rgbadata.size(); ++i)
    {
        temperatures[i] = rgbToColorTemperature(rgbadata[i]); // Calculate color temperature
    }

    std::sort(temperatures.begin(), temperatures.end()); // Sort the temperatures

    // Find the median value of the sorted temperatures
    auto median = temperatures.size() % 2 ?
        0.5 * (temperatures[temperatures.size() / 2 - 1] + temperatures[temperatures.size() / 2]) :
        temperatures[temperatures.size() / 2];
    return median; // Return the median temperature
}

// Function to sort images based on their median color temperatures in parallel
void parallel_sort(std::vector<std::string>& filenames)
{
    std::vector<std::pair<std::string, double>> imageWithMedians(filenames.size()); // Store filenames and medians
    std::mutex mtx;  // Mutex to protect shared data during parallel processing

    // Step 1: Calculate medians in parallel
#pragma omp parallel for
    for (size_t i = 0; i < filenames.size(); ++i)
    {
        double median = filename_to_median(filenames[i]); // Calculate median for each image
        std::lock_guard<std::mutex> lock(mtx);  // Lock to avoid race conditions
        imageWithMedians[i] = { filenames[i], median }; // Store the filename and its median
    }

    // Step 2: Sort images by their median temperatures in parallel
#pragma omp parallel
    {
        // Sort chunks of the data independently
#pragma omp for schedule(dynamic)
        for (size_t i = 0; i < imageWithMedians.size(); ++i)
        {
            std::sort(imageWithMedians.begin(), imageWithMedians.end(), [](const auto& lhs, const auto& rhs) {
                return lhs.second < rhs.second; // Compare medians to sort
                });
        }
    }

    // Step 3: Extract sorted filenames from the sorted data
    for (size_t i = 0; i < filenames.size(); ++i)
    {
        filenames[i] = imageWithMedians[i].first; // Update the filenames vector with sorted filenames
    }
}

int main()
{
    std::srand(static_cast<unsigned int>(std::time(NULL))); // Seed the random number generator

    const char* image_folder = "images/unsorted"; // Folder containing unsorted images

    if (!fs::is_directory(image_folder)) { // Check if the folder exists
        std::cerr << "Directory \"" << image_folder << "\" not found.\n"; // Print error message if not found
        return -1; // Exit program
    }

    std::vector<std::string> imageFilenames; // Vector to store image filenames
    for (auto& p : fs::directory_iterator(image_folder)) { // Iterate through the directory
        imageFilenames.push_back(p.path().u8string()); // Add each file path to the vector
    }

    std::cout << "Thread starting\n";

    auto start = std::chrono::high_resolution_clock::now(); // Start timing

    int numThreads = 8; // Number of threads to use
    omp_set_num_threads(numThreads); // Set OpenMP thread count

    std::thread sortThread(parallel_sort, std::ref(imageFilenames)); // Start a sorting thread

    std::cout << "Thread Launched!, Sorting images based on color temperature. Please wait...\n";

    if (sortThread.joinable()) { // Wait for the sorting thread to finish
        sortThread.join();
    }

    auto end = std::chrono::high_resolution_clock::now(); // End timing
    std::chrono::duration<double> elapsed = end - start; // Calculate elapsed time
    std::cout << "Sorting completed in " << elapsed.count() << " seconds.\n";

    std::cout << "Thread Finished!, displaying sorted images now!\n";

    // Create a new window for displaying images
    sf::RenderWindow sortedWindow(sf::VideoMode(800, 600), "Sorted Image Fever", sf::Style::Titlebar | sf::Style::Close);
    sortedWindow.setVerticalSyncEnabled(true); // Enable vertical sync for smoother display

    int imageIndex = 0; // Index of the current image to display
    sf::Texture texture; // Texture for displaying images
    texture.loadFromFile(imageFilenames[imageIndex]); // Load the first image
    sf::Sprite sprite(texture); // Create a sprite for the texture
    sprite.setScale(SpriteScaleFromDimensions(texture.getSize(), 800, 600)); // Scale the sprite to fit the window

    // Main loop for displaying images
    while (sortedWindow.isOpen()) {
        sf::Event event; // Event handling
        while (sortedWindow.pollEvent(event)) { // Check for user input
            if (event.type == sf::Event::Closed) // Close the window if requested
                sortedWindow.close();
            else if (event.type == sf::Event::KeyPressed) { // Handle keyboard input
                if (event.key.code == sf::Keyboard::Right) { // Next image
                    if (++imageIndex >= imageFilenames.size()) imageIndex = 0;
                    texture.loadFromFile(imageFilenames[imageIndex]); // Load the next image
                    sprite.setTexture(texture);
                }
                else if (event.key.code == sf::Keyboard::Left) { // Previous image
                    if (--imageIndex < 0) imageIndex = imageFilenames.size() - 1;
                    texture.loadFromFile(imageFilenames[imageIndex]); // Load the previous image
                    sprite.setTexture(texture);
                }
            }
        }

        sortedWindow.clear(); // Clear the window
        sortedWindow.draw(sprite); // Draw the sprite
        sortedWindow.display(); // Display the updated window
    }

    return 0; // Exit program
}
