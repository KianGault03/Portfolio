   M S B A M L   `   `   `  ����L  HKwikMedicalUI_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:KwikMedicalUI_WPFKwikMedicalUI_WPF  5   	   $    KwikMedicalUI_WPF.CallOperator   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:KwikMedicalUI_WPF     5   	     � Title$  CallOperator��5   	   $	��450��6   $	��800��6+   .��5	      � .+�5
   
   �� -   5         ��Name$ 	Image_NHS��5
      $
��Left=�6#   $��536,-20,0,0q�6>   $	��Top=�6S   $!��/nhs-logo-digital-space.jpg��6k   $	��184��6�   $	��464��6�   �� 5   
   -   5         ��Name$ 	TxtB_Line��5      $��Center=�6'   $��	0,114,0,0q�6D   $
��Wrap=�6W   $Y��S___________________________________________________________________________________��6k   $	��Top=�6�   $��36��6�   $	��780��6�   $��24(�6�   �� 5   
   -   5        $ 
txtB_Title��5      $
��Left=�6(   $��65��6C   $��	10,10,0,0q�6O   $
��Wrap=�6b   $'��!Call Operator Hub: Incoming Call!��6v   $	��Top=�6�   $	��450��6�   $��24(�6�   $��	Underline{�6�   $(��"Segoe UI Variable Display Semibold)�6�   �� 5   
   $
��Name��6   $
��Left=�6   $��29��6:   $��
26,153,0,0q�6F   $	��Top=�6Z   $��63��6r   $��18(�6}   �� 5   
   $��
CHI Number��6   $
��Left=�6%   $��29��6@   $��
26,193,0,0q�6L   $	��Top=�6`   $	��110��6x   $��18(�6�   �� 5   
   $��Address��6   $
��Left=�6"   $��35��6=   $��
26,237,0,0q�6I   $	��Top=�6]   $��76��6u   $��18(�6�   �� 5   
   $��Medical Condition��6   $
��Left=�6,   $��45��6G   $��
26,277,0,0q�6S   $	��Top=�6g   $	��164��6   $��18(�6�   �� 5   
   -   5         ��Name$ txt_Name��5      $
��Left=�6$   $��22��6?   $��
89,160,0,0q�6K    �� TextWrapping$
 Wrap=�6_   $	��Top=�6s   $	��170��6�   $��16(�6�    J� RenderTransformOrigin$ 0.515,0.584&�6�   �� 5   
   -   5        $ txt_CHINumber��5      $
��Left=�6)   $��22��6D   $��141,200,0,0q�6P   $
 Wrap=�6e   $	��Top=�6y   $	��170��6�   $��16(�6�   �� 5   
   -   5        $ txt_Address��5      $
��Left=�6'   $��22��6B   $��108,244,0,0q�6N   $
 Wrap=�6c   $	��Top=�6w   $	��204��6�   $��16(�6�   �� 5   
   -   5        $ txt_MedicalCondition��5      $
��Left=�60   $��22��6K   $��195,284,0,0q�6W   $
 Wrap=�6l   $	��Top=�6�   $	��186��6�   $��16(�6�   �� 5   
   $%��Search for Patient (CHI Number)��6   $
��Left=�6:   $��42��6U   $��	10,51,0,0q�6a   $	��Top=�6t   $	��292��6�   $��18(�6�   �� 5   
   -   5        $ txt_SearchCHI��5      $
��Left=�6)   $��22��6D   $��
283,61,0,0q�6P   $
 Wrap=�6d   $	��Top=�6x   $	��170��6�   $��16(�6�   �� 5   
   -	   5         ��Name$ 
btn_Search��5      $��Search��6%   $
��Left=�66   $��22��6Q   $��
330,92,0,0q�6]   $	��Top=�6q   $��70��6�   $��14(�6�   6�   �� 5   
   -
   5        $ btn_CreateNewRecord��5      $��Create new record��6.   $
��Left=�6J   $��33��6e   $��
26,327,0,0q�6q   $	��Top=�6�   $	��145��6�   $��16(�6�   6�   �� 5   
   -   5        $ btn_SendPatientRecords��5      $��Send records to ambulance��61   $
��Left=�6U   $��33��6p   $��570,327,0,0q�6|   $	��Top=�6�   $	��209��6�   $��16(�6�   6�   �� 5   
   -   5        $ 	btn_Clear��5      $��Clear��6$   $
��Left=�64   $��33��6O   $��713,155,0,0q�6[   $	��Top=�6p   $��52��6�   $��16(�6�   6�   5      5      