   M S B A M L   `   `   `  ���� Q  MCourseProjectOOPVer2.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:CourseProjectOOPVer2._0.ViewCourseProjectOOPVer2._0.View  0    *CourseProjectOOPVer2._0.View.CommentWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     <local*clr-namespace:CourseProjectOOPVer2._0.View       � Title$*  $Комментарии к посту��$��689.333��$	��660�� � WindowStyle$ 
ToolWindow=� � 
ResizeMode$ NoResize=�.���  � RowDefinitions �� $
��auto �$	��300���� $
��auto �.+�� .+��� $	��200��.��� $��Center=�.+��� $��Center=�$
��auto��$	��200��$��Center=�$��Center=����� *CurrentPost+����  �� 
TargetType" ��.���  �� Property � {� �� Value .  ���� .R�+   %CourseProjectOOPVer2._0.View.PostView  �� $9��3Написать новый комментарий:��$
��Left=�$	��Top=�$��10,380.2,0,-330.6q�$��1��$	��634���� $
��Left=�$��28�� �� TextWrapping$
 Wrap=�$	��Top=�$	��523��$��9,409.2,0,-356.4q�$��1������ *Textt+ �� Mode$ TwoWay=��� 
���   �$��1q�$
��Left=�$��1��$��
10,6.2,0,0q�$��1��$	��Top=�$	��634���� 	 �� 	IsDefault	 . $��0q�$��Отправить�����#6BBF90$
��Left=�$��537,405.2,0,-357.2q�$��1��$	��Top=�$	��106��
����������� *CreateComment+�� $	��363��$��0,12.2,-0.4,-292.8q�$��1��$	��Top=�$��Stretch=�.��� $	��624��.+��� $��Center=�$
��auto������ *CurrentComments+���� " ��.���  � ��$ 5q���  � {� .  ���� .R�.   (CourseProjectOOPVer2._0.View.CommentView  �� 
���   �$��1q�$
��Left=�$��1��$��9,375.2,0,-301q�$��1��$	��Top=�$	��634��