   M S B A M L   `   `   `  ????I  EMVVM_Mulitview, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:MVVM_Mulitview.ViewMVVM_Mulitview.View  5      '    !MVVM_Mulitview.View.CustomersView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:MVVM_Mulitview.View     5        ? 	Resources  5
         CustomerDataTemplate ?? Orientation" ?? ValidatesOnNotifyDataErrors??%?   &	        ?? 5   
   .R?5      ?? $ 
Horizontal=?6   .+?5      ?? $
??Bold"?6\   ??6   ?? *	FirstName+ .  6p   ?? 5      $??5 0 0 0q?67   ??6   ?? *
LastName+6J   5      5      5      .??5      ?  ? ColumnDefinitions 5   
   ?? 5      $
??Auto ?6   ?? 5      ?? 5      $
??Auto ?6   .+?5    
   ? -   5         ?Name$ customerListGrid??5       $??0??6   ???#777 ? RowDefinitions 5"      ?? 5#      $
??Auto ?6    ?? 5$      .+?5&      ?? $ 
Horizontal=?6   .+?5'      ?? $??10q?6   $??75??6%   ??60   ?? *
AddCommand+.??5(      ?? $ 
Horizontal=?6!   .+?5*      ?? $	??Add??6$   5+      5,      ?? 5-      $??Delete??6   $??75??6*   $??
0 10 10 10q?65   ??6I   ?? *DeleteCommand+?? 5.      $??
0 10 10 10q?6   ??6-   ?? *MoveNavigationCommand+50      51      ?? 52      $??1??6   $??
10 0 10 10q?6$   #??[  56      ??54      ?? *	Customers+ ?? SelectedItem 55      ?? *SelectedCustomer+ ?? Mode$ TwoWay=?56      5:      ?? 5=   
   $??1??6   $??10q?6%   .+?5>      ?? .??6   
Firstname:6    ?? 5?      ??6   ?? *SelectedCustomer.FirstName+$ TwoWay=? ?? UpdateSourceTrigger$ PropertyChanged=??? 5@      .??6   	Lastname:6   ?? 5A      ??6   ?? *SelectedCustomer.LastName+$ TwoWay=?$ PropertyChanged=??? 5B      $??0 10 0 0q?6   	 d? 	IsChecked	 6)   ?? *SelectedCustomer.IsDeveloper+$ TwoWay=?$ PropertyChanged=?5D      5F      5G      