   M S B A M L   `   `   `  ����  QUIZ_PROJECT    QUIZ_PROJECT.LoginWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Login��5   	   $	��486��6   $	��438��6$    � WindowStartupLocation$ CenterScreen=�60    � 
ResizeMode$ NoResize=�6U   ���#F7FAFC���#CBD5E0$��1q�6�    � 	Resources 5         RoundedTextBoxStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius	 ��Name  RoundedPasswordBoxStyle  RoundedButtonStyle
 �� Padding��%  &	        &	 �     &	 �    �� 5   
   " ��6,   .�5	      ��  � �� 5
      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5   !   $��1q�5   !   $ 5��5   !   ._�5      �� $	 PART_ContentHost��6+   5      5      5      5      �� 5   
   " G�60   .�5      ��  � �� 5      �� 5      " G�6&   .R�5      �� #��z��6!   #��z��5   !   $��1q�5   !   $ 5��5   !   ._�5       �� $	 PART_ContentHost��6+   5!      5"      5$      5%      �� 5(   
   " ��6+   .�5)      ��  � �� 5*      �� 5+      " ��6&   .R�5,      �� #��z��6!   #��z��5-   !   $ 20��5.   !   #
 z��5/   !   ._�50      �� $��Center=�6/   $��Center=�6L   51      52      54      55      56      .��58      � $��20q�6   .+�59   
   �� 
�������$
 20q�6$   ���#E2E8F0$��1q�6G   $ 10��6[    J� Effect 5:      3  -System.Windows.Media.Effects.DropShadowEffect  5;         Color$
 Gray��6#      
BlurRadius$ 10Q�60      ShadowDepth$ 0Q�6@   ._�5>      �� .+�5@      �� $��Welcome Back!��6   $��24(�61   $
��Bold"�6?   ���#2D3748$��Center=�6f   $��0,0,0,20q�6�   �� 5A      $��Please log in to continue��6   $��14(�6=   ���#4A5568$��Center=�6`   $��0,0,0,20q�6}   �� 5D      $��Username��6   $��14(�6,   $��0,0,0,5q�6:   ���#4A55686K   �� 5E      -   5         ��Name$ UsernameTextBox��5E      $��16(�63   $��10q�6A   ���#CBD5E0���#EDF2F7$��0,0,0,15q�6y   #��[  5F      �� 5I      $��Password��6   $��14(�6,   $��0,0,0,5q�6:   ���#4A55686K   G� 5J      -   5         G�Name$ PasswordBox��5J      $��16(�63   $��10q�6A   ���#CBD5E0���#EDF2F7$��0,0,0,20q�6y   #��[ 5K      �� 5N      -   5        $��Login��5N      $	��120��6)   $��40��65   $��16(�6A   $
��Bold"�6O   ���#4C51BF
�������$��0q�5O   A   $��Center=�5P       � Cursor$
 Hand��6P   #��[ 5Q      �� 5T      $��Forgot your password?��6   $��12(�69   ���#718096$��Center=�6\   $��0,20,0,0q�6y   $��	Underline{�6�   $
 Hand��6�   5U      5V      5W      5X      