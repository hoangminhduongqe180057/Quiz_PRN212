   M S B A M L   `   `   `  ����  QUIZ_PROJECT!    QUIZ_PROJECT.CategoriesPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        N� Title$  CategoriesPage��5       N� 
Background �#F7FAFC � 	Resources 5         CenteredCellStyle �� 
TargetType �� Property �� Value  RoundedButtonStyle �� 
TargetType �� CornerRadius �� Padding	 �� Triggers
 P� Property P� Value��%�  &	        &	 t     �� 5   
   " ��6*   .�5	      ��  � ��$ Center=�64   �� 5
       � ��$ Center=�62   5      �� 5   
   " ��6+   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5   !   $ 10��5   !   # z��5   !   ._�5      �� $��Center=�6/   $��Center=�6L   5      	 5      P� 5      
 �@J�IsMouseOver$
 True��6=   . �5   "   ��  � �� �#4C566A6?   5      5      5      5       5!      .��5#      � $��20q�6   .+�5$   
   �� $��Center=�6   $	��Top=�62   $	��600��6J   .+�5'      �� $��Manage Categories��6   $��24(�61   $
��Bold"�6?   ���#2D3748$��Center=�5(      $��0,0,0,20q�65   �� 5+      
����������#CBD5E0$��1q�6>   $ 10��6R   $ 10q�6d   $��0,0,0,20q�6q   ._�5,      �� $
��Auto=�6   .��5-      &   System.Windows.Controls.DataGrid  -   5          Name$ CategoriesDataGrid��5-         AutoGenerateColumns$ False��6;      HeadersVisibility$ Column=�6W      GridLinesVisibility$
 None=�5.         CanUserAddRows$ False��6:   
�������   AlternatingRowBackground �#F3F4F6
������ $��5q�5/   \   $��16(�50         ColumnHeaderHeight$ 40Q�6-      	RowHeight$ 35Q�6E   $	��200��6T      ColumnHeaderStyle 51      �� 52      =  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6$   .�53   "   ��  � ��$ Center=�6O   �� 54   "    � ��$
 Bold"�6?   �� 55   "    � ��$ 18(�6=   �� 56   "    � �� �#2D37486?   57         Columns 59      0  *System.Windows.Controls.DataGridTextColumn  5:      ,  &System.Windows.Controls.DataGridColumn   Header$ Category Name��61      Width5  /System.Windows.Controls.DataGridLengthConverter$ 2* 6a   1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# [  5;   1      Binding 5:   H   �� *Name+5;   1   4  .System.Windows.Controls.DataGridTemplateColumn  5<      $ Actions��65   $
 1.5* 6F      CellTemplate 5=   "   �� 5>   &   .R�5?   *   ��  �� Orientation$ 
Horizontal=�65   $��Center=�6N   .+�5@   .   �� -   5        $
��Edit��5@   5   $��50��6D   $	��2,0q�6O   #��[ 5A   5   �� 5B   .   -   5        $��Delete��5B   5   $��60��6F   $	��2,0q�6Q   #��[ 5C   5   5D   +   5E   '   5G      5I      5J      5K      �� 5N      ���#E6F0FA���#5E81AC$��1q�6@   $ 10��6T   $ 20q�6f   ._�5O      �� $��Center=�6   $��Center=�6:   $	��500��6U   .+�5P      �� $��Category Information��6    $��20(�6<   $
��Bold"�6J   ���#5E81AC$��Center=�5Q       $��0,0,0,20q�6=   �� 5S      $	��0,5q�6!   .+�5T      �� $��Category Name��6$   $��16(�69   $
��Bold"�6G   ���#4A5568$��0,0,0,5q�6n   �� 5U      -   5         ��Name$ CategoryNameTextBox��5U   "   $	��400��6?   $��30��6K   $��14(�6W   $��5q�6e   ���#CBD5E0$��1q�5V   8   5W      �� 5Y      -   5         ��Name$ SaveCategoryButton��5Y   5   $��Save Category��6   $	��200��6l   $��40��6x   ���#5E81AC
�������
������ $
��Bold"�5[      $��16(�6/   $��0,20,0,0q�6=   #��[ 6O   5\      5]      5^      5_      5`      