   M S B A M L   `   `   `  ����  KwikMedicalUI_WPF&     KwikMedicalUI_WPF.AmbulancePhone   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$   Ambulance Phone Simulation��5   	   $	��600��6,   $	��350��69    � 
ResizeMode$ NoResize=�6E    � WindowStartupLocation$ CenterScreen=�6[   .��5      � $��10q�6   .+�5   
   �� .+�5
      �� $,��&Ambulance Interface (Phone Simulation)��6   $��16(�5      $
��Bold"�6&   $��Center=�68   $��0,0,0,20q�6U   �� 5      $��Patient Information:��6   $
��Bold"�64   $��0,0,0,10q�6F   �� 5      $
��10,0q�6   .+�5      �� $��Name:��6   $
��Bold"�6)   �� 5      -   5         ��Name$ txt_PatientName��5       �� 
IsReadOnly$
 True��63   
�������6E   �� 5      $��NHS CHI Num #:��6   $
��Bold"�62   $��0,10,0,0q�6D   �� 5      -   5        $ txt_PatientCHI��5      $
 True��62   
�������6D   �� 5      $��Address:��6   $
��Bold"�6,   $��0,10,0,0q�6>   �� 5      -   5        $ txt_PatientAddress��5      $
 True��66   
�������6H   �� 5      $��
Condition:��6   $
��Bold"�6.   $��0,10,0,0q�6@   �� 5      -   5        $ txt_PatientCondition��5      $
 True��68   
�������6J   5      �� 5      $��Response Details:��6   $
��Bold"�61   $��	0,20,0,10q�6C   �� 5      $
��10,0q�6   .+�5       �� $
��Who:��6   �� 5!      -   5        $ txt_ResponseWho��5!      $	��300��63   �� 5#      $��What:��6   $��0,10,0,0q�6)   �� 5$      -   5        $ txt_ResponseWhat��5$      $	��300��64   �� 5&      $��When:��6   $��0,10,0,0q�6)   �� 5'      -   5        $ txt_ResponseWhen��5'      $	��300��64   �� 5)      $��Where:��6   $��0,10,0,0q�6*   �� 5*      -   5        $ txt_ResponseWhere��5*      $	��300��65   5+      �� 5.      -	   5         ��Name$ btn_SaveResponse��5.      $��Save Response��6/   $	��150��5/      $��40��6!   $��Center=�6-   $��0,20,0,0q�50      6'   51      52      53      