   M S B A M L   `   `   `  ���� Q  MCourseProjectOOPVer2.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:CourseProjectOOPVer2._0.ViewCourseProjectOOPVer2._0.View  ,    &CourseProjectOOPVer2._0.View.LoginPage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     <local*clr-namespace:CourseProjectOOPVer2._0.View       N� Title$  	LoginPage�� � 	Resources  �� MergedDictionaries �� Source��  �� $2 ,pack://application:,,,/styles/regbutton.xaml?�%    .��� ���#6BBF90.+��� $��Center=�$��Center=�$	��338��$	��500��
�������$��390,140,390,202q� �� CornerRadius$ 10�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 20Q�   ShadowDepth$ 0Q�   Opacity$	 0.8Q�._�� .+��� $&�� Добро пожаловать!��$��Center=�$	��Top=�$��20q�$��20(��� $��Center=�$��40��	 �� TextWrapping$
	 Wrap=�$	��Top=�$	��380��$��	0,101,0,0q�$��20(����� *Email+
 �� Mode$
 TwoWay=�.������ .R��� $ 12�� �� Padding$ 2q�$��1q����#000000._���  ��Name$ PART_ContentHost��$��0q�.��G� -    G�Name$ PasswordBox��$��Center=�$��40��$	��Top=�$	��380��$��	0,180,0,0q�$��20(����� .R��� $ 12��$ 2q�$��1q����#000000._��� $ PART_ContentHost��$��0q��� $��Регистрация��$
��Left=�$��
60,286,0,0q�$	��Top=�$	��186��$��30��
�������$��20(����#6BBF90$��0q����� *Reg+  �� 
TargetType �� Property �� Value��%9   '��       �� " ��.���  �@��CornerRadius$ 5���� $��Вход��$
��Left=�$��255,286,0,0q�$	��Top=�$	��185��$��30�� �� 	IsDefault . 
�������$��20(����#6BBF90$��0q����� *Login+����  �� ElementName$ PasswordBox�� ��%9   '��       �� " ��.���  �@��CornerRadius$ 5���� $��Email��$
��Left=�$��	60,73,0,0q�$	��Top=�$��93��$��16(��� $��Пароль��$
��Left=�$��
60,152,0,0q�$	��Top=�$��93��$��16(��� $
��Left=�$��
60,262,0,0q�$	��Top=�$��24��$	��380��
���  ������ *Status+�� $
��Left=�$��
62,237,0,0q�$	��Top=�$��19��$��19�� d� 	IsChecked �� *
SaveUser+$
 TwoWay=� � LayoutTransform ��  �� ScaleX$	 1.2Q� �� ScaleY$	 1.2Q��� $1��+Запомнить пользователя��$
��Left=�$��
90,232,0,0q�$	��Top=�$	��267��$��16(�