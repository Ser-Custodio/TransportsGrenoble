   M S B A M L   `   `   `  ���� V  RTransportInterfaceGraphique, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:TransportInterfaceGraphique.Views!TransportInterfaceGraphique.Views  3    -TransportInterfaceGraphique.Views.StationView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Alocal/clr-namespace:TransportInterfaceGraphique.Views       � 	Resources     NoScroll 
 MyIcon �� 	UriSource��%=   &	        &	      �� .R��� �� $ /images/icon.png?�.��� .+��� .+��  � ColumnDefinitions �� $	��70* ��� $	��70* ��� $
��110* ��� $	��70* ��� $
��110* ��� $	��70* ��� $
��110* ��� $
��110* � � RowDefinitions �� .+��� $��20(�$��0��$��0��.��	Latitude:�� $��15(�$��1��$��0��$��10,7,0,0q�����  �� Path$ Latitude��� $��20(�$��2��$��0��.��
Longitude:�� $��15(�$��3��$��0��$��10,7,0,0q����� $ 	Longitude��� $��20(�$��4��$��0��.��	Distance:�� $��15(�$��5��$��0��$��10,7,0,0q����� $ Distance��� $��15(�$��6��$��0��$��20,0,0,0q����� $ 
FindLignes�.��
Rechercher�� $��0,50,0,0q�.+��� $��Liste des Arrets:��$��35(�$
��Bold"�$��Italic$�
����  ��� ���� $ Stations����� .R��� .+��� $��20(�$��DemiBold"�
����  �$��0,15,0,5q����� $ Arret�]� .+��� $��1q�
���   � �� CornerRadius$ 10��
������� �� Padding$ 5q�._��� $��listeLignes��#��[  ���� $ Lignes����� .R���  �� Orientation$ 
Horizontal=�.+��� $��30������ *Image+�� $��50��$��18(�$��0,0,0,5q����� $
 mode��� $��50�� �� TextAlignment$ Center=�$��18(�$
��Bold"�	 �� Padding$	 4,2,4,2q�$��10,0,0,0q����� $ 	shortName����� $ 	realColor��� $��18(�$��10,0,0,0q����� $ longName�