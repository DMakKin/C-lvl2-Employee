   M S B A M L   `   `   `  ����H  DEmploeeList 2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:EmploeeList_2EmploeeList_2  5   	       EmploeeList_2.EmpWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:EmploeeList_2     5   	   -   5          � Title$  	EmpWindow��5   	   $	��350��6   $	��550��6(   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��2* �6   �� 5      $��2* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DepForEmpDataGrid��5         AutoGenerateColumns .     EnableRowVirtualization . $��Stretch=�5   J      
IsReadOnly . $��2��5   %   $��4��65   ��5   2   ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        	DepColumn��,  &System.Windows.Controls.DataGridColumn   Header$ Департамент��5   %   	   
IsReadOnly	 . 
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 17* 6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5   8   �� *	DepName+5   L     5      -   5        idColumn��$ ID��5   %   	 . $
 5* 6C    5   7   �� *DepNum+5   C   5      �� 5    
   $��Stretch=�5!      $��Stretch=�6+   $��10,20q�6G   $
��Wrap=�6V   $��Фамилия:��6j   �� 5"   
   $��1��6   $��Stretch=�5#      $��Stretch=�6+   $��10,20q�6G   $
��Wrap=�6V   $��Имя:��6j   �� 5$   
   $��2��6   $��Stretch=�5%      $��Stretch=�6+   $��10,20q�6G   $
��Wrap=�6V   $��Возраст:��6j   �� 5&   
   $��3��6   $��Stretch=�5'      $��Stretch=�6+   $��10,20q�6G   $
��Wrap=�6V   $��Департамент:��6j   �� 5(   
   -   5        $��
SurnameBox��5(   "   $��1��6   $��Stretch=�5)      $��Stretch=�60   $��10,20q�6L    �� TextWrapping$
 Wrap=�6[   �� 5*   
   -   5        $��NameBox��5*   /   $��1��6   $��1��6"   $��Stretch=�5+      $��Stretch=�60   $��10,20q�6L   $
 Wrap=�6[   �� 5,   
   -   5        $��AgeBox��5,   /   $��1��6   $��2��6"   $��Stretch=�5-      $��Stretch=�60   $��10,20q�6L   $
 Wrap=�6[   �� 5.   
   -   5        $��DepBlock��5.   1   $��1��6   $��3��6$   $��Stretch=�5/      $��Stretch=�60   $��10,20q�6L   ��50      ��  �� ElementName$ DepForEmpDataGrid�� �� Path$ SelectedItem.DepNum� �� Mode$ TwoWay=��� 51   
   -	   5        $��
SaveButton��51      $��Сохранить��6#   $��Stretch=�52      $��Stretch=�6/   $��5,20,130,20q�53      $��1��6&   $��4��66   6C   �� 54   
   -
   5         ��Name$ ChancelButton��54      $��Отменить��6(   $��Stretch=�55      $��Stretch=�6/   $��5,20,130,20q�56      $��2��6&   $��4��66   6C   57      58      