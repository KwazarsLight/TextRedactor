   M S B A M L   `   `   `  ����C  ?Redactor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:RedactorRedactor  5   	       Redactor.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Redactor     5   	     � Title$  Redactor��5   	   $	��450��6   $	��800��6'   .��5
      �  � RowDefinitions 5   
   �� 5      $��8* �6   �� 5      $
��411* �6    � ColumnDefinitions 5   
   �� 5      .+�5   
   o� $��22��6   $	��Top=�6   $��2��63   .@�5      m� $
��File��6   .@�5      m� -   5        $��Create new file��5      6O   m� 5      -   5        $��Save current file��5      6V   m� 5      -   5        $��Close application��5      6O   5      m� 5      $��Database��6   .@�5      m� -   5        $��Dowload file��5      6M   5      5      �� 5   
   -   5         ��Name$ RedactorTextBox��5      $
��Left=�6+   $	��387��6F   $��	10,14,0,0q�6S    �� TextWrapping$
 Wrap=�6f    �� AcceptsReturn .  �� 
AcceptsTab .  $	��Top=�6�   $	��763��6�   $y�Hidden=�6�   $��1��6�   �� 5   
   -   5         ��Name$ StartInstructionsLabel��5      $;��5Let's write something!
Push File -> Create new file!��60   $
��Left=�6{   $��243,137,0,0q�6�   $	��Top=�6�   $��77��6�   $	��338��6�   $��24(�6�   $��Disabled=�6�   $��1��6  5      5      