   M S B A M L   `   `   `  ����@  <laba8, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:laba8laba8  5   	       laba8.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:laba8     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � $��10q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $C��=Матрица 10×10, заполненная змейкой:��6!   $
��Bold"�5      $��16(�6&   $��0,0,0,10q�64   �� 5   
   $��1��6   $
��Auto=�6$   .��5      �� -   5         ��Name$ MatrixTextBlock��5      $��Courier New)�61   $��14(�5      $��NoWrap=�6&   5      �� 5   
   -   5         ��Name$ RegenerateButton��5      $��2��6   $+��%Сгенерировать снова��68   $��Center=�5   0   $��0,10,0,0q�5      $
��10,5q�6#   $	��150��62   5      5      