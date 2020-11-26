﻿namespace Web.Models.Enum
{
    public enum PermissionTypes
    {
        SP_ACCESS = 1, // Доступ к данным научных проектов
        IA_ACCESS = 2, // Доступ к данным актам о внедрении
        BY_ACCESS = 3,  // Доступ к данным банка молодежи
        SP_PROJECTLISTVIEW_ALL = 4, // Доступ к чтению всех записей 
        SP_CAN_APPROVED = 5, // Доступ к согласованию проекта
        SP_CAN_EDIT_ALL = 6 // Доступ к редактированию всех научных проектов 
    }
}