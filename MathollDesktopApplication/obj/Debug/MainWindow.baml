   M S B A M L   `   `   `  ����V  RMaterial.Icons, Version=2.1.10.0, Culture=neutral, PublicKeyToken=34ed5903a64b4509G4clr-namespace:Material.Icons;assembly=Material.IconsMaterial.Icons  5   	   T PMathollDesktopApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:MathollDesktopApplicationMathollDesktopApplication 5   	   E'clr-namespace:MathollDesktopApplicationMathollDesktopApplication 5	   	   *   $MathollDesktopApplication.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   NmaterialIcons4clr-namespace:Material.Icons;assembly=Material.Icons     5   	   9local'clr-namespace:MathollDesktopApplication     5   	   S OHandyControl, Version=3.5.1.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol  5   	   5strings'clr-namespace:MathollDesktopApplication  5	   	   A =Wpf.Ui, Version=3.0.5.0, Culture=neutral, PublicKeyToken=null/ui&http://schemas.lepo.co/wpfui/2022/xaml  5
   	   -   5        "  Wpf.Ui.Controls.FluentWindow   Name$  
mainWindow��5   	    � Title$ BÓ Kitchen��5   	   $	��800��6   $
��1600��6)   $	��800��66   $	��400��6E    � 	Resources 5       �� Source�� 5   
   $8 2pack://application:,,,/Resources/ButtonStyles.xaml?�6   %     J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5        #  System.Windows.SystemCommands   MaximizeWindowCommand   Command# Z 5      6z     5   
   -   5           MinimizeWindowCommand# Z 5      6z   .��5      � -   5         �Name$ GridMainArea��5      .+�5   
   � -   5        $ 
GridHeader��5      $	��147��6#   $	��Top=�60   
���   �	 K� ZIndex$	 1��6v   .+�5      �� -   5        
 ��Name$
 	ImageLogo��5      $��Center=�6'   $
��Left=�6B   $��15,0,0,0q�6]   $��/bola_logo.png��6o   $	��127��6�   � 5      -   5        $ GridHeaderButtons��5      $	��Top=�6.   $��Right=�6F   $��52��6b   ���	#FF353535$	��164��6�   .+�5        Wpf.Ui.Controls.Button  -   5          Name$ BtnCloseApplication��5      $��X��69   $��Center=�6E   $��Right=�6`   
���  ��$��48(�6�   $��Arial Black)�6�   $��50��6�   $��50��6�   $��0,0,2,0q�6�   6�     5      -	   5        $ BtnMaximizeApplication��5      $��O��6<   #��Z 6H   $��Center=�6�   $��Right=�6�   $��0,0,57,0q�6�   ���	#FF61A6DC$��48(�6�   $��Arial Black)�6�   $��50��6	  $��50��6    5      -
   5        $ BtnMinimizeApplication��5      $��_��6<   #��Z 6H   $��Center=�6�   $��Right=�6�   $��	0,0,112,0q�6�   ���	#FF61A6DC$	��150(�6�   $��
Bauhaus 93)�6�   $��50��6
  $��50��6  5      5      � 5    
   -   5        $ GridMenu��5       $	��210��6!   $
��Left=�6-   
���   �$	 0��6[   .+�5!      �� -   5         ��Name$ BtnMenuButtonRecipes��5!      $��Uppskriftir��63   $
��Bold"�6I   $��32(�6[   $��Stretch=�6i   $��70��6�    J� Opacity$
 0.92Q�6�   $��	0,147,0,0q�6�   $	��Top=�6�   ���	#FF21441C��5"      �� 5#       �� 
TargetType" ��6&   .R�5$      ��  ��Name$ border��6!   #��z��61   #��z��6[   $��0q�6�    �� CornerRadius$ 0��6�   ._�5%      ��  ��Name$ contentPresenter��6/   $��Center=�6I   $��Center=�6f   5&       �� Triggers 5'      P� 5(       P� Property �@J�IsMouseOver P� Value . . �5)   "   ��  �� 
TargetName$ border��6)    �� Property � �� �� Value
 ����6S   �� 5*   "   $ contentPresenter��6)    � ��
 ��  �6i   �� 5+   "   $ contentPresenter��6)    � ��$
 Bold"�6i   5,      P� 5-       � �� . . �5.   "   �� $ border��6)    � ��
 � d �6S   5/      P� 50       � {� .  . �51   "   �� $ border��6)    � ��
 �����6S   52      54      56      �� 57      -   5        $ BtnMenuButtonUsers��57      $��Notendur��61   $
��Bold"�6D   $��Stretch=�6V   $��70��6t   $
 0.92Q�6�   $��	0,217,0,0q�6�   $	��Top=�6�   ���	#FF21441C��58      �� 59      " ��6&   .R�5:      �� $ border��6!   #��z��61   #��z��6[   $��0q�6�   $ 0��6�   ._�5;      �� $ contentPresenter��6/   $��Center=�6I   $��Center=�6f   5<       5=      P� 5>       �@J�IsMouseOver . . �5?   "   �� $ border��6)    � ��
 ����6S   �� 5@   "   $ contentPresenter��6)    � ��
 ��  �6i   �� 5A   "   $ contentPresenter��6)    � ��$
 Bold"�6i   5B      P� 5C       � �� . . �5D   "   �� $ border��6)    � ��
 � d �6S   5E      P� 5F       � {� .  . �5G   "   �� $ border��6)    � ��
 �����6S   5H      5J      5L      �� 5M      -   5        $ BtnMenuButtonSousVide��5M      $��	Sous Vide��64   $
��Bold"�6H   $��Stretch=�6Z   $��70��6x   $
 0.92Q�6�   $��	0,287,0,0q�6�   $	��Top=�6�   ���	#FF21441C��5N      �� 5O      " ��6&   .R�5P      �� $ border��6!   #��z��61   #��z��6[   $��0q�6�   $ 0��6�   ._�5Q      �� $��Center=�6/   $��Center=�6L   5R       5S      P� 5T       �@J�IsMouseOver . . �5U   "   �� $ border��6)    � ��
 ����6S   5V      P� 5W       � �� . . �5X   "   �� $ border��6)    � ��
 � d �6S   5Y      P� 5Z       � {� .  . �5[   "   �� $ border��6)    � ��
 �����6S   5\      5^      5`      �� 5a      -   5        $ BtnMenuButtonAirFryer��5a      $��	Air Fryer��64   $
��Bold"�6H   $��Stretch=�6Z   $	��Top=�6x   $��	0,357,0,0q�6�   $��70��6�   $
 0.92Q�6�   ���	#FF21441C��5b      �� 5c      " ��6&   .R�5d      �� $ border��6!   #��z��61   #��z��6[   $��0q�6�   $ 0��6�   ._�5e      �� $��Center=�6/   $��Center=�6L   5f       5g      P� 5h       �@J�IsMouseOver . . �5i   "   �� $ border��6)    � ��
 ����6S   5j      P� 5k       � �� . . �5l   "   �� $ border��6)    � ��
 � d �6S   5m      P� 5n       � {� .  . �5o   "   �� $ border��6)    � ��
 �����6S   5p      5r      5t      �� 5u      -   5        $ BtnMenuButtonSettings��5u      $��
Stillingar��64   $
��Bold"�6I   $��Stretch=�6[   $��Bottom=�6y   $��70��6�   $
 0.92Q�6�   $��0,0,0,70q�6�   ���	#FF21441C��5v      �� 5w      " ��6&   .R�5x      �� $ border��6!   #��z��61   #��z��6[   $��0q�6�   $ 0��6�   ._�5y      �� $��Center=�6/   $��Center=�6L   5z       5{      P� 5|       �@J�IsMouseOver . . �5}   "   �� $ border��6)    � ��
 ����6S   5~      P� 5       � �� . . �5�   "   �� $ border��6)    � ��
 � d �6S   5�      P� 5�       � {� .  . �5�   "   �� $ border��6)    � ��
 �����6S   5�      5�      5�      �� 5�      -   5        $ BtnMenuButtonLogout��5�      $��Útskráning��62   $
��Bold"�6G   $��Stretch=�6Y   $��70��6w   $
 0.92Q�6�   $��0,0,0,0q�6�   $��Bottom=�6�   
���\\����5�      �� 5�      " ��6&   .R�5�      �� $ border��6!   #��z��61   #��z��6[   $��0q�6�   $ 0��6�   ._�5�      �� $��Center=�6/   $��Center=�6L   5�       5�      P� 5�       �@J�IsMouseOver . . �5�   "   �� $ border��6)    � ��
 ����6S   5�      P� 5�       � �� . . �5�   "   �� $ border��6)    � ��
 � d �6S   5�      P� 5�       � {� .  . �5�   "   �� $ border��6)    � ��
 �����6S   5�      5�      5�      5�      �� 5�   
   -   5         ��Name$ ScrollViewerRecipes��5�      $
��Auto=�64   $��228,157,18,12q�6W    J� RenderTransformOrigin$ 0.5,0.5&�6n   z�5�      V� 5�      .~�5�      �� �� 5�       �� AngleX$ -0.134Q�6$   �� 5�      T� 5�       T� X$ 0.748Q�6)   5�      .��5�      �� -   5         ��Name$ MainContentControl��5�      5�      5�      5�      