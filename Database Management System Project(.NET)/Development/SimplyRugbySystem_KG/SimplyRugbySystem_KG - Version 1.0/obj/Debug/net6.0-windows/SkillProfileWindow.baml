   M S B A M L   `   `   `  ����]  YSimplyRugbySystem_KG - Version 1.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:SimplyRugbySystem_KG___Version_1._0#SimplyRugbySystem_KG___Version_1._0  5   	   <    6SimplyRugbySystem_KG___Version_1._0.SkillProfileWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Clocal1clr-namespace:SimplyRugbySystem_KG___Version_1._0     5   	     � Title$  SkillProfileWindow��5   	   $	��652��6$   $
��1439��61   .��5	      � $��Center=�6   $
��1439��6(   $��0,0,0,-6q�65   ��5
   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ Black��6   � 5      $ White��6    � Offset$ 1Q�6-   5      .+�5   
   �� -   5         ��Name$ 	listItems��5      $��25,32,140,0q�6&   $	��195��6;   $	��Top=�6H   ���	#FFD6D4D4 �� View 5      �� 5      .P�5      �� $	��SRU��6%    �� Width$ 50��62    �� DisplayMemberBinding 6=   �� *SRU+�� 5      $��Player Name��6%   $	 120��6:    6F   �� *Name+�� 5      $��Passing: Standard��6%   $	 100��6@    6L   �� *PassingStandard+�� 5      $��Passing: Spin��6%   $	 100��6<    6H   �� *PassingSpin+�� 5      $��Passing: Pop��6%   $	 100��6;    6G   �� *
PassingPop+�� 5      $��Tackling: Front��6%   $	 100��6>    6J   �� *TacklingFront+�� 5      $��Tackling: Rear��6%   $	 100��6=    6I   �� *TacklingRear+�� 5      $��Tackling: Side��6%   $	 100��6=    6I   �� *TacklingSide+�� 5      $��Tackling: Scrabble��6%   $	 100��6A    6M   �� *TacklingScrabble+�� 5      $��Kicking: Drop��6%   $	 100��6<    6H   �� *KickingDrop+�� 5      $��Kicking: Punt��6%   $	 100��6<    6H   �� *KickingPunt+�� 5      $��Kicking: Grubber��6%   $	 100��6?    6K   �� *KickingGrubber+�� 5      $��Kicking: Goal��6%   $	 100��6<    6H   �� *KickingGoal+5       5"      �� 5#   
   $��Passing: Spin��6   $
��Left=�6(   $��
17,362,0,0q�6C   $	��Top=�6W   $��14(�6o   	 J� RenderTransformOrigin$	 0.545,1.469&�6}   �� 5$   
   $��Passing: Pop��6   $
��Left=�6'   $��
20,407,0,0q�6B   $	��Top=�6V   $��14(�6n   �� 5%   
   -   5        
 ��Name$
 btn_UpdateRecord��5%      $��Update Skill��6+   $
��Left=�6B   $��
25,471,0,0q�6]   $	��Top=�6q   $	��118��6�   $��36��6�   $��14(�6�   6�   �� 5&   
   $��Passing: Standard��6   $
��Left=�6,   $��	6,317,0,0q�6G   $	��Top=�6Z   $��14(�6r   �� 5'   
   -   5        $
 btn_Unselect��5'      $��Unselect Item��6'   $
��Left=�6?   $��1147,229,0,0q�6Z   $	��Top=�6p   $	��128��6�   $��16(�6�   �� 5(   
   $��Search for User ID��6   $
��Left=�6-   $��
25,230,0,0q�6H   $	��Top=�6\   $��14(�6t   �� 5)   
   -   5         ��Name$ 
txt_Search��5)      $
��Left=�6&   $��155,234,0,0q�6A    �� TextWrapping$
 Wrap=�6V   $	��Top=�6j   $	��120��6�   $��14(�6�   �� 5*   
   -   5        $
 
btn_Search��5*      $��Search��6%   $
��Left=�66   $��296,235,0,0q�6Q   $	��Top=�6f   $��70��6~   6�   �� 5+   
   -   5        $
 btn_PlayerDetailsWindow��5+      $��Player Records��62   $
��Left=�6K   $��1304,48,0,0q�6f   $	��Top=�6{   $	��116��6�   $��40��6�   $��16(�6�   �� 5,   
   $��Tackling: Front��6   $
��Left=�6*   $��225,312,0,0q�6E   $	��Top=�6Z   $��14(�6r   �� 5-   
   $��Tackling: Rear��6   $
��Left=�6)   $��228,345,0,0q�6D   $	��Top=�6Y   $��14(�6q   $	 0.495,0.075&�6   �� 5.   
   $��Tackling: Side��6   $
��Left=�6)   $��228,382,0,0q�6D   $	��Top=�6Y   $��14(�6q   �� 5/   
   $��Tackling: Scrabble��6   $
��Left=�6-   $��215,424,0,0q�6H   $	��Top=�6]   $��14(�6u   �� 50   
   $��Kicking: Drop��6   $
��Left=�6(   $��416,311,0,0q�6C   $	��Top=�6X   $��14(�6p   �� 51   
   $��Kicking: Punt��6   $
��Left=�6(   $��419,345,0,0q�6C   $	��Top=�6X   $��14(�6p   �� 52   
   $��Kicking: Grubber��6   $
��Left=�6+   $��408,387,0,0q�6F   $	��Top=�6[   $��14(�6s   $	 0.514,0.473&�6�   �� 53   
   $��Kicking: Goal��6   $
��Left=�6(   $��419,420,0,0q�6C   $	��Top=�6X   $��14(�6p   �� 54   
   $��Current Team: ��6   $
��Left=�6)   $��25,3,0,0q�6D   $	��Top=�6V   $��14(�6n   
�������6|   �� 55   
   -   5         ��Name$ txtblk_CurrentTeam��55      $
��Left=�60   $��
124,10,0,0q�6K   $
��Wrap=�6_   $	��Top=�6s   $��76��6�   $��14(�6�   
�������6�   �� 56   
   -   5         ��Name$ comboBox_Standard��56      $
��Left=�6x   $��129,322,0,0q�6�   $	��Top=�6�   $��39��6�   $	 0.462,0.457&�6�    �� Text 6.   ��  �� ElementName$ 	listItems�� �� Path$" SelectedItem.PassingStandard�6�   �� 57   
   -	   5        $ comboBox_Spin��57      $
��Left=�6p   $��129,366,0,0q�6�   $	��Top=�6�   $��39��6�   $	 0.538,0.548&�6�    6*   �� $ 	listItems��$ SelectedItem.PassingSpin�6�   �� 58   
   -
   5        $ comboBox_Pop��58      $
��Left=�6n   $��129,411,0,0q�6�   $	��Top=�6�   $��39��6�    6)   �� $ 	listItems��$ SelectedItem.PassingPop�6�   �� 59   
   -   5        $ comboBox_Front��59      $
��Left=�6s   $��346,315,0,0q�6�   $	��Top=�6�   $��39��6�    6+   �� $ 	listItems��$  SelectedItem.TacklingFront�6�   �� 5:   
   -   5        $ comboBox_Rear��5:      $
��Left=�6q   $��346,346,0,0q�6�   $	��Top=�6�   $��39��6�    6*   �� $ 	listItems��$ SelectedItem.TacklingRear�6�   �� 5;   
   -   5        $ comboBox_Side��5;      $
��Left=�6q   $��346,385,0,0q�6�   $	��Top=�6�   $��39��6�    6*   �� $ 	listItems��$ SelectedItem.TacklingSide�6�   �� 5<   
   -   5        $ comboBox_Scrabble��5<      $
��Left=�6y   $��346,427,0,0q�6�   $	��Top=�6�   $��39��6�    6.   �� $ 	listItems��$# SelectedItem.TacklingScrabble�6�   �� 5=   
   -   5        $ comboBox_Drop��5=      $
��Left=�6p   $��524,311,0,0q�6�   $	��Top=�6�   $��39��6�    6*   �� $ 	listItems��$ SelectedItem.KickingDrop�6�   �� 5>   
   -   5        $ comboBox_Punt��5>      $
��Left=�6p   $��525,347,0,0q�6�   $	��Top=�6�   $��39��6�    6*   �� $ 	listItems��$ SelectedItem.KickingPunt�6�   �� 5?   
   -   5        $ comboBox_Grubber��5?      $
��Left=�6v   $��524,390,0,0q�6�   $	��Top=�6�   $��40��6�    6-   �� $ 	listItems��$! SelectedItem.KickingGrubber�6�   �� 5@   
   -   5        $ comboBox_Goal��5@      $
��Left=�6p   $��524,424,0,0q�6�   $	��Top=�6�   $��40��6�    6*   �� $ 	listItems��$ SelectedItem.KickingGoal�6�   �� 5A   
   -   5         ��Name$ checkBox_Juniors��5A      $��Junior Squad��6-   $
��Left=�6D   $��452,234,0,0q�6_   $	��Top=�6t   $��16(�6�   �� 5B   
   -   5        $ checkBox_Under18s��5B      $��Under 18s Squad��6.   $
��Left=�6H   $��579,234,0,0q�6c   $	��Top=�6x   $��16(�6�   �� 5C   
   -   5        $ checkBox_18Plus��5C      $��18 -20 Squad��6,   $
��Left=�6C   $��725,235,0,0q�6^   $	��Top=�6s   $��16(�6�   �� 5D   
   -   5        $ checkBox_21Plus��5D      $��	21+ Squad��6,   $
��Left=�6@   $��858,234,0,0q�6[   $	��Top=�6p   $��16(�6�   �� 5E   
   -   5        $
 
btn_LogOut��5E      $��log Out��6%   $
��Left=�67   $��1304,111,0,0q�6R   $	��Top=�6h   $��16(�6�   $	��116��6�   $��36��6�   6�   �� 5F   
   $
��Left=�6   $	��243��6+   $��961,339,0,0q�68   $	��Top=�6M   $	��368��6e   $��/Simply Rugby Logo.png��6q   5H      5I      