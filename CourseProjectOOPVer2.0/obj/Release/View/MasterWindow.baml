   M S B A M L   `   `   `  ���� Q  MCourseProjectOOPVer2.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:CourseProjectOOPVer2._0.ViewCourseProjectOOPVer2._0.View  /    )CourseProjectOOPVer2._0.View.MasterWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     <local*clr-namespace:CourseProjectOOPVer2._0.View       � Title$   ��$	��720��$
��1280�� � WindowStyle$
 None=� � WindowState$ 	Maximized=�$	��720��$
��1280�� � Icon$&  pack://application:,,,/logo1.png��.��� .+�� ���	#FF1C995A$��Stretch=�$��40��$	��Top=�$
��Auto��$��
0,0,-0.4,0q�.+��� $��до связи��$
��Left=�$	��Top=�$��	160,3,0,0q�$��30��$��20(�$
��Bold"�$��Trebuchet MS)��� $��40��$��40��$
��Left=�$	��Top=�$1��+/CourseProjectOOPVer2.0;component/logo1.png��$
��Fill=�$��	120,0,0,0q�� $��Center=�$
��auto�� � ColumnDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� $��Stretch=�$	��Top=�$��0q�$��40��$	��150�����	#FF1C995A
���   �$��0,0,0,0q����� *
OpenNews+.��� $��40��$	��120��.+��� $0��*pack://application:,,,/styles/NewsMenu.png��$��
87,10,0,10q��� $��Новости��$��33,12,38,10q�$��11(��� $��Stretch=�$	��Top=�$��0q�$	��150��$��40�����	#FF1C995A
���   �$��0,0,0,0q�$��1������ *Home+.��� $��40��$	��120��.+��� $2��,pack://application:,,,/styles/MyPageMenu.png��$��
83,10,0,10q��� $��Моя страница��$��10,12,37,10q�$��11(��� $
��Left=�$	��Top=�$	��150��$��40�����	#FF1C995A
���   �$��0,0,0,0q�$��3������ *MessageList+.��� $��40��$	��120��.+��� $4��.pack://application:,,,/styles/MessagesMenu.png��$��
83,10,0,10q��� $��Сообщения��$��16,12,42,10q�$��11(��� $��Stretch=�$	��Top=�$	��150��$��40�����	#FF1C995A
���   �$��0,0,0,0q�$��2������ *
FriendList+.��� $��40��$	��120��.+��� $(��"Запросов в друзья: ��$��7(�
��� ���$��-13,-2,62,25q�y��� *CountFriendRequestsVis+�� $3��-pack://application:,,,/styles/FriendsMenu.png��$��
85,10,0,10q��� $��Друзья��$��37,12,40,10q�$��11(��� $��7(�
���  ��$��
57,-2,0,25q�$
��auto��$
��Left=����� *CountFriendRequests+y��� *CountFriendRequestsVis+�� $��
Выход��$��Right=�$��
0,7,62.6,0q�$	��Top=�$��75�����	#FF1C995A���	#FF009846$��25��$��0,0,0,0q�
���   ����� *Exit+�� 
�������$��X��$��Right=�$	��Top=�$��23��
���   �$��	0,7,5.6,0q�$��25��$��0,0,0,0q�
���   ����� *ShDw+�� 
�������$��_��$	��Top=�$��Right=�$	��Top=�$��23��
���   �$��
0,7,33.6,0q�$��25��$��0,0,0,0q�
���   ����� *Min+ � -   $��	MainFrame��  � NavigationUIVisibility$ Hidden=�$��0,40,-0.4,-0.4q����� *CurrentPage+ J� Opacity �� *FrameOpacity+