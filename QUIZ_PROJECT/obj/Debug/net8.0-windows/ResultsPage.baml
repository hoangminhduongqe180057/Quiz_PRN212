   M S B A M L   `   `   `  ����  QUIZ_PROJECT    QUIZ_PROJECT.ResultsPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        N� Title$  ResultsPage��5       N� 
Background �#F7FAFC � 	Resources 5         CenteredCellStyle �� 
TargetType �� Property �� Value  RoundedButtonStyle �� 
TargetType �� CornerRadius �� Padding	 �� Triggers
 P� Property P� Value��%�  &	        &	 t     �� 5   
   " ��6*   .�5	      ��  � ��$ Center=�64   �� 5
       � ��$ Center=�62   5      �� 5   
   " ��6+   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5   !   $ 10��5   !   # z��5   !   ._�5      �� $��Center=�6/   $��Center=�6L   5      	 5      P� 5      
 �@J�IsMouseOver$
 True��6=   . �5   "   ��  � �� �#4C566A6?   5      5      5      5       5!      .��5#      � $��20q�6    � RowDefinitions 5$   
   �� 5%      $
��Auto �6   �� 5'      $��* �6   �� 5)      $
��Auto �6   .+�5.   
   �� $��0��6   $��Center=�6"   $��0,0,0,10q�6?   .+�5/      �� $��Quiz Results��6   $��24(�6,   $
��Bold"�6:   ���#2D37486L   �� 50      $��16(�51      $��SemiBold"�6&   ���#4A5568��50      ��  �� Path$ 	_userName� �� RelativeSource ��  �� AncestorType Page51   <   52      �� 55   
   $��1��6   
����������#CBD5E0$��1q�6G   $ 10��6[   $ 10q�6m   $
��0,10q�6z   ._�56      &   System.Windows.Controls.DataGrid  -   5          Name$ ResultsDataGrid��56         AutoGenerateColumns$ False��60      HeadersVisibility$ Column=�6L      GridLinesVisibility$
 None=�6g      CanUserAddRows$ False��57         
IsReadOnly$
 True��6.   
�������   AlternatingRowBackground �#F3F4F6
������ $��16(�58         ColumnHeaderHeight$ 40Q�6%      	RowHeight$ 40Q�6=   $	��650��6L      ColumnHeaderStyle 5;      �� 5<      =  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�5=      ��  � ��$ Center=�6G   �� 5>       � ��$
 Bold"�67   �� 5?       � ��$ 18(�65   �� 5@       � �� �#2D374867   5A         Columns 5E      0  *System.Windows.Controls.DataGridTextColumn  5F      ,  &System.Windows.Controls.DataGridColumn   Header$ Student Name��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6`   1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# [  5G   )      Binding 5F   ?   �� *Student.Name+5G   )     5H      $ 
Quiz Title��6)   $ * 6\   # [  5I   )    5H   =   �� *
Quiz.Title+5I   )     5J      $ Score��6)   $	 100 6R   # [  5K   )    5J   8   �� *Score+5K   )     5L      $ 
Date Taken��6)   $	 160 6[   # [  5M   )    5L   =   �� *	DateTaken+5M   )   5O      5P      5[      5\      