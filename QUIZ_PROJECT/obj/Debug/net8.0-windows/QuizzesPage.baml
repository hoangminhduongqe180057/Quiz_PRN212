   M S B A M L   `   `   `  ����  QUIZ_PROJECT    QUIZ_PROJECT.QuizzesPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        N� Title$  Manage Quizzes��5       N� 
Background �#F7FAFC � 	Resources 5         CenteredCellStyle �� 
TargetType �� Property �� Value  RoundedButtonStyle �� 
TargetType �� CornerRadius �� Padding	 �� Triggers
 P� Property P� Value��%�  &	        &	 t     �� 5   
   " ��6*   .�5	      ��  � ��$ Center=�64   �� 5
       � ��$ Center=�62   5      �� 5   
   " ��6+   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5   !   $ 10��5   !   # z��5   !   ._�5      �� $��Center=�6/   $��Center=�6L   5      	 5      P� 5      
 �@J�IsMouseOver$
 True��6=   . �5   "   ��  � �� �#4C566A6?   5      5      5      5       5!      .��5#      �� $
��Auto=�6   .��5$   
   � $��20q�6   .+�5%      �� $��Center=�6   $	��Top=�66   $	��700��6N   .+�5(      �� $��Manage Quizzes��6   $��24(�62   $
��Bold"�6@   ���#2D3748$��Center=�5)      $��0,0,0,20q�69   �� 5,      
����������#CBD5E0$��1q�6B   $ 10��6V   $ 10q�6h   $��0,0,0,20q�6u   ._�5-      &   System.Windows.Controls.DataGrid  -   5          Name$ QuizzesDataGrid��5-         AutoGenerateColumns$ False��68      HeadersVisibility$ Column=�6T      GridLinesVisibility$
 None=�5.         CanUserAddRows$ False��6:   
�������   AlternatingRowBackground �#F3F4F6
������ $��5q�5/   \   $��16(�50         ColumnHeaderHeight$ 40Q�6-      	RowHeight$ 40Q�6E   $	��650��6T      ColumnHeaderStyle 51      �� 52      =  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6$   .�53   "   ��  � ��$ Center=�6O   �� 54   "    � ��$
 Bold"�6?   �� 55   "    � ��$ 18(�6=   �� 56   "    � �� �#2D37486?   57         Columns 59      0  *System.Windows.Controls.DataGridTextColumn  5:      ,  &System.Windows.Controls.DataGridColumn   Header$ Title��61      Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 6Z   1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# [  5;   1      Binding 5:   @   �� *Title+5;   1     5<      $ Category��61   $	 150 6e   # [  5=   1    5<   C   �� *Category.Name+5=   1   4  .System.Windows.Controls.DataGridTemplateColumn  5>      $ Actions��65   $	 348 6F      CellTemplate 5?   "   �� 5@   &   .R�5A   *   ��  �� Orientation$ 
Horizontal=�65   $��Center=�6N   $	��5,0q�6k   .+�5B   .   �� -   5        $
��Edit��5B   5   $��75��6D   $	��2,0q�6O   #��[ 5C   5   �� 5D   .   -   5        $��Delete��5D   5   $��80��6F   $	��2,0q�6Q   #��[ 5E   5   �� 5F   .   -   5        $��Manage Questions��5F   5   $	��150��6P   $	��2,0q�6\   #��[ 5G   5   5H   +   5I   '   5K      5M      5N      �� 5Q      ���#E6F0FA���#5E81AC$��1q�6D   $ 10��6X   $ 20q�6j   ._�5R      �� $��Center=�6!   $��Center=�6>   $	��500��6Y   .+�5S      �� $��Quiz Information��6$   $��20(�6<   $
��Bold"�6J   ���#5E81AC$��Center=�5T   $   $��0,0,0,20q�6A   �� 5W      $	��0,5q�6%   .+�5X      �� $��
Quiz Title��6(   $��16(�6:   $
��Bold"�6H   ���#4A5568$��0,0,0,5q�6o   �� 5Y      -   5         ��Name$ QuizTitleTextBox��5Y   &   $	��400��6@   $��30��6L   $��14(�6X   $��5q�6f   ���#CBD5E0$��1q�5Z   <   5[      �� 5^      $	��0,5q�6%   .+�5_      �� $��Category��6(   $��16(�68   $
��Bold"�6F   ���#4A5568$��0,0,0,5q�6m   �� 5`      -   5         ��Name$ CategoryComboBox��5`   '   $	��400��6A   $��30��6M   $��14(�6Y   ���#CBD5E0$��1q�5a   =    �� DisplayMemberPath$
 Name��6Q    �� SelectedValuePath$ Id��5b   '   5c      �� 5f      -   5        $��AddQuiz_Button��5f   !   $��	Save Quiz��67   $	��200��6a   $��40��6m   ���#5E81AC
�������
������ $
��Bold"�5h   !   $��16(�63   $��0,20,0,0q�6A   #��[ 6S   5i      5j      5k      5l      5m      5n      