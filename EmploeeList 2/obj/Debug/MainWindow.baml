   M S B A M L   `   `   `  ����H  DEmploeeList 2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:EmploeeList_2EmploeeList_2  5   	       EmploeeList_2.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:EmploeeList_2     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � 	Resources 5	          EmploeeList_2.ConvertToDep   ConvertToDep��%   &	          5
   
   6   5      .��5      � -   5         � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��3* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ EmployeeDataGrid��5         AutoGenerateColumns .     EnableRowVirtualization . $��Stretch=�5   J      
IsReadOnly . $��1��5   %   $��5��65   ��5   2   ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        idColumn��,  &System.Windows.Controls.DataGridColumn	   Header$	 ID��5   %   
   
IsReadOnly
 .    Width5  /System.Windows.Controls.DataGridLengthConverter$ 5* 6C   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5   7   �� *ID+5   C     5      -   5        	SurColumn��$	 Фамилия��5    %   
 . $	 15* 6H    5   8   �� *	Surname+5    H     5!      -   5        
NameColumn��$	 Имя��5"   %   
 . $	 10* 6D    5!   9   �� *Name+5"   D     5#      -   5        	AgeColumn��$	 Возраст��5$   %   
 . $ 8* 6H    5#   8   �� *Age+5$   H     5%      -   5        	DepColumn��$	 Департамент��5&   %   
 . $	 17* 6L    5%   8   �� *Dep+ �� 	Converter# [  5&   L   5(      �� 5)   
   -   5        $��AddEmpButton��5)      $+��%Добавить сотрудника��6%   $��15, 25q�6C   $��Stretch=�5*      $��Stretch=�60   6L   �� 5+   
   -	   5        $��ChangeEmpButton��5+      $+��%Изменить сотрудника��6(   $��15, 25q�6F   $��1��6V   $��Stretch=�5,      $��Stretch=�60   6L   �� 5-   
   -
   5        $��	DepButton��5-      $��Департамент��6"   $��15, 25q�68   $��2��6H   $��Stretch=�5.      $��Stretch=�60   6L   �� 5/   
   -   5        $��Refresh��5/      $��Обновить��6    $��50, 25q�63   $��3��6C   $��Stretch=�50      $��Stretch=�60   6L   �� 51   
   -   5        $��DeleteButton��51      $��Удалить��6%   $��15, 25q�67   $��4��6G   $��Stretch=�52      $��Stretch=�60   6L   53      54      