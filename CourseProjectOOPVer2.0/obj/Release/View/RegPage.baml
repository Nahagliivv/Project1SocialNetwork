   M S B A M L   `   `   `  ���� Q  MCourseProjectOOPVer2.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:CourseProjectOOPVer2._0.ViewCourseProjectOOPVer2._0.View  U/clr-namespace:CourseProjectOOPVer2._0.ViewModel!CourseProjectOOPVer2._0.ViewModel  *    $CourseProjectOOPVer2._0.View.RegPage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     <local*clr-namespace:CourseProjectOOPVer2._0.View     =c/clr-namespace:CourseProjectOOPVer2._0.ViewModel       N� Title$  RegPage�� � 	Resources 8   2CourseProjectOOPVer2._0.ViewModel.MyMultiConverter   Convert �� MergedDictionaries �� Source��  �� $2 ,pack://application:,,,/styles/regbutton.xaml?�%   &	          .��� ���#6BBF90.+��� $��Center=�$��Center=�$	��575��$	��500��
������� �� CornerRadius$ 10�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 20Q�   ShadowDepth$ 0Q�   Opacity$	 0.8Q�._�� .+��� $��Регистрация��$��Center=�$	��Top=�$��20q�$��20(��� $��Center=�$��40��	 �� TextWrapping$
	 Wrap=�$	��Top=�$	��380��$��60,105,60,0q�$��20(�.������ .R��� $ 12��
 �� Padding$
 2q�$��1q����#000000._���  ��Name$ PART_ContentHost��$��0q�.������  �� Path$ Email� �� Mode$ TwoWay=� �� ValidatesOnExceptions . .��G� -    G�Name$ PasswordBox��$��Center=�$��40��$	��Top=�$	��380��$��60,345,60,0q�$��20(����� .R��� $ 12��$
 2q�$��1q����#000000._��� $ PART_ContentHost��$��0q��� $��Регистрация�� �� 	IsDefault . $
��Left=�$��
60,506,0,0q�$	��Top=�$	��380��$��30��
�������$��20(����#6BBF90$��0q����� *CreateAccount+  �� 
TargetType �� Property �� Value��%9   '��       �� " ��.���  �@��CornerRadius$ 5����`�  `� 	Converter# [  .1���  �� ElementName$ PasswordBox���� $ PasswordBox_Copy���� $��14(�$��Вход��$
��Left=�$��
387,28,0,0q�$	��Top=�$��53��$��21��
����������#6BBF90$��0q����� *Login+ ��%9   '��       �� " ��.���  �@��CornerRadius$ 5���� $'��!Электронная почта��$
��Left=�$��	60,77,0,0q�$	��Top=�$	��169��$��16(��� $��Пароль��$
��Left=�$��
60,317,0,0q�$	��Top=�$��93��$��16(�G� -   $ PasswordBox_Copy��$��Center=�$��40��$	��Top=�$	��380��$��60,425,60,0q�$��20(����� .R��� $ 12��$
 2q�$��1q����#000000._��� $ PART_ContentHost��$��0q��� $%��Повторите пароль��$
��Left=�$��
60,397,0,0q�$	��Top=�$	��153��$��16(��� $��Center=�$��40��$
	 Wrap=�$	��Top=�$	��380��$��60,265,60,0q�$��20(����� *
Lastname+$ TwoWay=�.������ .R��� $ 12��$
 2q�$��1q����#000000._��� $ PART_ContentHost��$��0q�.���� $��Фамилия��$
��Left=�$��
60,237,0,0q�$	��Top=�$	��169��$��16(��� $��Center=�$��40��$
	 Wrap=�$	��Top=�$	��380��$��60,186,60,0q�$��20(�.������ .R��� $ 12��$
 2q�$��1q����#000000._��� $ PART_ContentHost��$��0q�.������ $ 	Firstname�$ TwoWay=� .  �� ValidationRules 5  /System.Windows.Controls.ExceptionValidationRule  .���� $��Имя��$
��Left=�$��
60,158,0,0q�$	��Top=�$	��169��$��16(��� $
��Left=�$��
60,465,0,0q�$	��Top=�$��41��$	��Top=�$	��380��
���  ������ *ErrorMessage+