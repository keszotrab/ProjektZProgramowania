   M S B A M L   `   `   `  ���� P  LProjektZProgramowania, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ProjektZProgramowaniaProjektZProgramowania  &     ProjektZProgramowania.CartWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5local#clr-namespace:ProjektZProgramowania       � Title$  
CartWindow��$	��450��$	��800�� � 	Resources ��%    .��� 
������� � RowDefinitions �� $	��110 ���  � ColumnDefinitions �� $	��210 ��� �� $	��220 �.+��� $��0��$��0�����	#FFE6DD7E�� $��0��$��1�����	#FFE6DD7E�� $��0��$��2�����	#FFE6DD7E�� $
��Wrap=�$��0��$��2��$��Zawartość koszyka��$��42(� �� TextAlignment$ Center=�$��Center=��� $��0��$��2�� �� Orientation$ 
Horizontal=�$��RightToLeft=�  �� 
TargetType �� Property �� Value��%5   '��       �� " ��.���  � ��$ 
10,10,10,0q�.+��� -   	 ��Name$	 	buyButton��$��90��$��90��.���� $
��Wrap=�$	��Kup��$��20(��� -   $	 clearCartButton��$��90��$��90��.���� $
��Wrap=�$��Wyczyść koszyk��$��20(�� $��0��$��2��$��1�� �� $��40 ���  �� $��90 ��� $��2* ��� .+��� $
��Wrap=�$�� ��$��20(�$��0���� $
��Wrap=�$��Nazwa��$��20(�$��1���� $
��Wrap=�$
��Cena��$��20(�$��2���� -   
 ��Name$
 	cartImgSP��$��1��$��0���� -   $
 
cartNameSP��$��1��$��1���� -   $
 cartPriceSP��$��1��$��2���� $��2��$��1��.+��� $
��Wrap=�$��Łączny koszt��$��20(�$ Center=��� -    ��Name$ 	totalCost��$
��Wrap=�$��	tutajcena��$��20(�$ Center=��� $
��Wrap=�$
��Imie��$��20(��� -    ��Name$ customerName�� �� TextWrapping$
 Wrap=�$�� ��$	��120���� $
��Wrap=�$��Nazwisko��$��20(��� -   $ customerSurename��$
 Wrap=�$�� ��$	��120���� $
��Wrap=�$��Adres zamieszkania��$��20(��� -	   $ customerHomeAddress��$
 Wrap=�$�� ��$	��120���� $
��Wrap=�$��Adres dostawy��$��20(��� -
   $ customerDeliveryAddress��$
 Wrap=�$�� ��$	��120���� $
��Wrap=�$��Email��$��20(��� -   $ customerEmail��$
 Wrap=�$�� ��$	��120��