   M S B A M L   `   `   `  ����  KwikMedicalUI_WPF(    "KwikMedicalUI_WPF.RegionalHospital   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$'  !Regional Hospital Staff Interface��5   	   $	��700��63   $	��600��6@    � 
ResizeMode$ 	CanResize=�6L    � WindowStartupLocation$ CenterScreen=�6c   .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $��* �6   .+�5   
   �� $��0��6   $'��!Regional Hospital Staff Interface��6!   $��18(�5      $
��Bold"�6"   $��Center=�64   $��0,0,0,20q�6Q   �� 5   
   $��1��6   $��10q�6"   .+�5      �� $��Patient Information��6   $��0,0,0,20q�64   .��5      �� $��10q�6   .+�5      �� $��Name:��6    $
��Bold"�6-   �� 5      -   5         ��Name$ txt_PatientName��5       �� 
IsReadOnly$
 True��67   
�������6I   �� 5      $��NHS CHI Num:��6    $
��Bold"�64   $��0,10,0,0q�6F   �� 5      -   5        $ txt_PatientCHI��5      $
 True��66   
�������6H   �� 5      $��Address:��6    $
��Bold"�60   $��0,10,0,0q�6B   �� 5      -   5        $ txt_PatientAddress��5      $
 True��6:   
�������6L   �� 5      $��
Condition:��6    $
��Bold"�62   $��0,10,0,0q�6D   �� 5      -   5        $ txt_PatientCondition��5      $
 True��6<   
�������6N   5       5!      �� 5$      $��Ambulance Crew Response��6   $��0,0,0,20q�68   .��5%      �� $��10q�6   .+�5&      �� $
��Who:��6    $
��Bold"�6,   �� 5'      -   5        $ txt_ResponseWho��5'      $
 True��67   
�������6I   �� 5)      $��What:��6    $
��Bold"�6-   $��0,10,0,0q�6?   �� 5*      -   5        $ txt_ResponseWhat��5*      $
 True��68   
�������6J   �� 5,      $��When:��6    $
��Bold"�6-   $��0,10,0,0q�6?   �� 5-      -   5        $ txt_ResponseWhen��5-      $
 True��68   
�������6J   �� 5/      $��Where:��6    $
��Bold"�6.   $��0,10,0,0q�6@   �� 50      -   5        $ txt_ResponseWhere��50      $
 True��69   
�������6K   51      52      �� 55       �� Orientation$ 
Horizontal=�6   $��Right=�62   $��0,20,0,0q�6N   .+�56      �� -	   5         ��Name$ btn_Confirm��56      $��Confirm Patient Received��6.   $	��200��57      $��40��6%   $��0,0,10,0q�61   6C   �� 58      -
   5        $ 	btn_Close��58      $��Close��6,   $	��100��59      $��40��6%   61   5:      5;      5<      5=      