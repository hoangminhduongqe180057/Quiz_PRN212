   M S B A M L   `   `   `  ����  QUIZ_PROJECT    QUIZ_PROJECT.UsersPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        N� Title$  	UsersPage��5       N� 
Background �#F7FAFC � 	Resources 5         CenteredCellStyle �� 
TargetType �� Property �� Value  RoundedButtonStyle �� 
TargetType �� CornerRadius �� Padding	 �� Triggers
 P� Property P� Value��%�  &	        &	 t     �� 5   
   " ��6*   .�5	      ��  � ��$ Center=�64   �� 5
       � ��$ Center=�62   5      �� 5   
   " ��6+   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5   !   $ 10��5   !   # z��5   !   ._�5      �� $��Center=�6/   $��Center=�6L   5      	 5      P� 5      
 �@J�IsMouseOver$
 True��6=   . �5   "   ��  � �� �#4C566A6?   5      5      5      5       5!      .��5#      � $��20q�6   .+�5$   
   �� $��Center=�6   $	��Top=�62   $	��600��6J   .+�5'      �� $��Manage Users��6   $��24(�6,   $
��Bold"�6:   ���#2D3748$��Center=�5(      $��0,0,0,20q�65   �� 5+      
����������#CBD5E0$��1q�6>   $ 10��6R   $ 10q�6d   $��0,0,0,20q�6q   ._�5,      �� $
��Auto=�6   .��5-      &   System.Windows.Controls.DataGrid  -   5          Name$ UsersDataGrid��5-         AutoGenerateColumns$ False��66      HeadersVisibility$ Column=�6R      GridLinesVisibility$
 None=�5.         CanUserAddRows$ False��6:   
�������   AlternatingRowBackground �#F3F4F6
������ $��5q�5/   \   $��16(�50         ColumnHeaderHeight$ 40Q�6-      	RowHeight$ 35Q�6E   $	��200��6T      ColumnHeaderStyle 51      �� 52      =  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6$   .�53   "   ��  � ��$ Center=�6O   �� 54   "    � ��$
 Bold"�6?   �� 55   "    � ��$ 18(�6=   �� 56   "    � �� �#2D37486?   57         Columns 59      0  *System.Windows.Controls.DataGridTextColumn  5:      ,  &System.Windows.Controls.DataGridColumn   Header$ Username��61      Width5  /System.Windows.Controls.DataGridLengthConverter$ 2* 6`   1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# [  5;   1      Binding 5:   C   �� *
Username+5;   1     5<      $
 Role��61   $ 2* 6X   # [  5=   1    5<   ?   �� *Role+5=   1   4  .System.Windows.Controls.DataGridTemplateColumn  5>      $ Actions��65   $
 1.5* 6F      CellTemplate 5?   "   �� 5@   &   .R�5A   *   ��  �� Orientation$ 
Horizontal=�65   $��Center=�6N   .+�5B   .   �� -   5        $
��Edit��5B   5   $��50��6D   $	��2,0q�6O   #��[ 5C   5   �� 5D   .   -   5        $��Delete��5D   5   $��60��6F   $	��2,0q�6Q   #��[ 5E   5   5F   +   5G   '   5I      5K      5L      5M      �� 5Q      ���#E6F0FA���#5E81AC$��1q�6@   $ 10��6T   $ 20q�6f   ._�5R      �� $��Center=�6   $��Center=�6:   $	��500��6U   .+�5S      �� $��User Information��6    $��20(�68   $
��Bold"�6F   ���#5E81AC$��Center=�5T      $��0,0,0,20q�61   �� 5W      $	��0,5q�6!   .+�5X      �� $
��Name��6$   $��16(�60   $
��Bold"�6>   ���#4A5568$��0,0,0,5q�6e   �� 5Y      -   5         ��Name$ NameTextBox��5Y   "   $	��400��67   $��30��6C   $��14(�6O   $��5q�6]   ���#CBD5E0$��1q�5Z   +   5[      �� 5_      $	��0,5q�6!   .+�5`      �� $��Username��6$   $��16(�64   $
��Bold"�6B   ���#4A5568$��0,0,0,5q�6i   �� 5a      -   5        $ UsernameTextBox��5a   "   $	��400��6;   $��30��6G   $��14(�6S   $��5q�6a   ���#CBD5E0$��1q�5b   ,   5c      �� 5f      $	��0,5q�6!   .+�5g      �� $��Password��6$   $��16(�64   $
��Bold"�6B   ���#4A5568$��0,0,0,5q�6i   G� 5h      -   5         G�Name$ PasswordTextBox��5h   &   $	��400��6?   $��30��6K   $��14(�6W   $��5q�6e   ���#CBD5E0$��1q�5i   0   5j      �� 5m      $	��0,5q�6!   .+�5n      �� $
��Role��6$   $��16(�60   $
��Bold"�6>   ���#4A5568$��0,0,0,5q�6e   �� 5o      -   5         ��Name$ RoleComboBox��5o   #   $	��400��69   $��30��6E   $��14(�6Q   ���#CBD5E0$��1q�6u   .@�5p      �� $��Admin��6+   �� 5q      $��Teacher��6+   �� 5r      $��Student��6+   5s      5t      �� 5w      -   5        $
��Save��5w      $	��200��6B   $��40��6N   ���#5E81AC
�������
������ $
��Bold"�5y      $��16(�6#   $��0,20,0,0q�61   #��[ 6C   5z      5{      5}      5~      5      