   M S B A M L   `   `   `  ���� Q  MCourseProjectOOPVer2.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:CourseProjectOOPVer2._0.ViewCourseProjectOOPVer2._0.View  ,    &CourseProjectOOPVer2._0.View.CheckCode   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     <local*clr-namespace:CourseProjectOOPVer2._0.View       N� Title$  	LoginPage�� � 	Resources  �� MergedDictionaries �� Source��  �� $2 ,pack://application:,,,/styles/regbutton.xaml?�%    .��� ���#6BBF90.+��� $��Center=�$��Center=�$	��216��$	��500��
�������$��390,200,390,264q� �� CornerRadius$ 10�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 20Q�   ShadowDepth$ 0Q�   Opacity$	 0.8Q�._�� .+��� $<��6Введите код, полученный на Email��$��Center=�$	��Top=�$��
88,10,88,0q�$��20(��� $��Center=�$��40��	 �� TextWrapping$
	 Wrap=�$	��Top=�$	��380��$��	0,101,0,0q�$��20(����� *EnteredCode+
 �� Mode$
 TwoWay=�.������ .R��� $ 12�� �� Padding$ 2q�$��1q����#000000._���  ��Name$ PART_ContentHost��$��0q�.���� $��Подтвердить��$
��Left=�$��254,165,0,0q�$	��Top=�$	��186��$��30��
�������$��20(����#6BBF90$��0q����� *	Confirm+  �� 
TargetType �� Property �� Value��%9   '��       �� " ��.���  �@��CornerRadius$ 5���� $
��Left=�$��	60,51,0,0q�$	��Top=�$
��auto��$��16(�$��50���� $V�PДля подтверждения регистрации на почту был ���� �� $5�/отправлен 6-ти значный код���� $
��Left=�$��
60,141,0,0q�$	��Top=�$��24��$	��380��
���  ������ *Status+�� $��Отмена��$
��Left=�$��
60,165,0,0q�$	��Top=�$	��186��$��30��
�������$��20(����#6BBF90$��0q����� *GoBack+ ��%9   '��       �� " ��.���  �@��CornerRadius$ 5��