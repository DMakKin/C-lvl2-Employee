   M S B A M L   `   `   `  ����H  DEmploeeList 2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:EmploeeList_2EmploeeList_2  5   	       EmploeeList_2.DepWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:EmploeeList_2     5   	     � Title$  	DepWindow��5   	   $	��400��6   $	��500��6(   .��5	      � -   5         � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��2* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DepDataGrid��5         AutoGenerateColumns .     EnableRowVirtualization . $��Stretch=�5   J      
IsReadOnly . $��1��5   %   $��4��65   ��5   2   ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        	DepColumn��,  &System.Windows.Controls.DataGridColumn   Header$ Департамент��5   %   	   
IsReadOnly	 . 
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 17* 6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5   8   �� *	DepName+5   L     5      -   5        idColumn��$ ID��5   %   	 . $
 5* 6C    5   7   �� *DepNum+5   C   5      �� 5   
   -   5        $��
DepNameBox��5      $��15,30q�6$   $��Stretch=�5      $��Stretch=�61   ��5       ��  �� ElementName$ DepDataGrid�� �� Path$ SelectedItem.DepName� �� Mode$ OneWay=��� 5!   
   -   5        $��AddNameButton��5!      $��Добавить��6&   $��15,30q�69   $��1��6H   $��Stretch=�5"      $��Stretch=�60   6L   �� 5#   
   -   5        $��ChangeNameButton��5#      $��Изменить��6)   $��15,30q�6<   $��2��6K   $��Stretch=�5$      $��Stretch=�60   6L   �� 5%   
   -   5        $��ChancelButton��5%      $��Отмена��6&   $��15,30q�67   $��3��6F   $��Stretch=�5&      $��Stretch=�60   6L   5'      5(      