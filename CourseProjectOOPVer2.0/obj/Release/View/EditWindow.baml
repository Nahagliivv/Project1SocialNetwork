   M S B A M L   `   `   `  ���� Q  MCourseProjectOOPVer2.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:CourseProjectOOPVer2._0.ViewCourseProjectOOPVer2._0.View  -    'CourseProjectOOPVer2._0.View.EditWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     <local*clr-namespace:CourseProjectOOPVer2._0.View     b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -     � Title$   ��$��390.047��$��336.296�� � 
ResizeMode$ NoResize=� J� SnapsToDevicePixels .  � Icon$&  pack://application:,,,/logo1.png�� � 	Resources  �� MergedDictionaries �� Source��  �� $2 ,pack://application:,,,/styles/regbutton.xaml?�%    .��� .+��� $0��*Изменить фото страницы��$
��Left=�$	��Top=�$	��310��$��	10,10,0,0q�$��27��
����������#6BBF90$��0q�$��12(����� *EdPic+  �� 
TargetType �� Property	 �� Value��%9   '��       �� " ��.���  �@��CornerRadius$	 5���� $��Пол:��$
��Left=�$��	10,42,0,0q�$	��Top=�$��92���� $ ��Дата рождения:��$
��Left=�$��	10,89,0,0q�$	��Top=�$	��107���� $��Страна: ��$
��Left=�$��
10,140,0,0q�$	��Top=�$	��107���� $��Город:��$
��Left=�$��
10,194,0,0q�$	��Top=�$	��107���� $��О себе:��$
��Left=�$��
10,249,0,0q�$	��Top=�$��92��
 J� RenderTransformOrigin$
 0.028,0.644&��� $
��Left=�$��
122,42,0,0q�$	��Top=�$	��190��$��24�� �� Text �� *Sex+.@��� 	Муж.�� 	Жен.(  "System.Windows.Controls.DatePicker  $
��Left=�$��
122,89,0,0q�$	��Top=�$	��190��$��2q�|�.     DisplayDateStart �� *	DateStart+ �� Mode$ OneWay=�   DisplayDateEnd �� *	DateEnd+$ OneWay=�   SelectedDate �� *
BirthDay+�� $
��Left=�$��23��$��122,141,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��190������ *	Country+$ TwoWay=��� $
��Left=�$��23��$��122,195,0,0q�$
 Wrap=�$	��Top=�$	��190������ *City+$ TwoWay=��� $
��Left=�$��122,253,0,0q�$
 Wrap=�$	��Top=�$��53��$	��190��$��1,1,1,1q����� *AboutMyself+$ TwoWay=���  �� 	IsDefault . $��Сохранить��$
��Left=�$	��Top=�$	��302��$��
10,311,0,0q�$��29��$��12(�
����������#6BBF90$��0q����� *SaveChanges+ ��%9   '��       �� " ��.���  �@��CornerRadius$	 5��