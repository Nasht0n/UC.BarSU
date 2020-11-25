namespace Web.Models.Enum
{
    public enum PermissionTypes
    {
        SP_ACCESS = 1, // Доступ к данным научных проектов
        IA_ACCESS = 2, // Доступ к данным актам о внедрении
        BY_ACCESS = 3,  // Доступ к данным банка молодежи
        SP_PROJECTLISTVIEW_ALL = 5, // Доступ к чтению всех записей 
        SP_PROJECTLISTVIEW_OWN = 6, // Доступ к чтению только своих записей
        SP_CAN_APPROVED = 7, // Доступ к согласованию проекта
        SP_CAN_EDIT_ALL = 8 // Доступ к редактированию всех научных проектов 
    }
}