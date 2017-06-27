using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sales.MVCClient.Helper
{
    public static class MagicString
    {
        public const string PathAccountDataBase = "SalesAccountDataBaseContext";
        public const string PathSalesDataBase = "SalesDataBaseContext";

        public const string RolesAdmin = "admin";
        public const string RolesUser = "user";

        public const string ErrorWrongLoginOrPassword = "Неверный логин или пароль.";
        public const string ErrorNoMore50CharactersInString = "Длина строки должна быть не более 50 символов";

        public const string DisplayPassword = "Пароль";
        public const string DisplayConfirmPassword = "Подтверждение пароля";

        public const string DisplayUserName = "Имя пользователя";
        public const string DisplayUserUserName = "Никнейм";
        public const string DisplayUserEmail = "Электронная почта";
        public const string DisplayUserAddress = "Домашний адрес";
        public const string DisplayUserRoles = "Права доступа";

        public const string DisplayClientName = "Имя клиента";
        public const string DisplayManagerName = "Имя менеджера";
        public const string DisplayProduct = "Товар";
        public const string DisplayDateSetPrice = "Дата установки цены";
        public const string DisplayProductPrice = "Цена товара";
        public const string DisplayProductName = "Название товара";
        public const string DisplaySessionName = "Имя сессии";
        public const string DisplayDateOfSession = "Дата сессии";

        public const string DisplayOperaionDate = "Дата операции";
        public const string DisplayOperationManager = "Менеджер";
        public const string DisplayOperationClient = "Клиент";
        public const string DisaplyOpertionProduct = "Товар";
        public const string DisplayOpertionPrice = "Цена";
        public const string DisplayOperationSession = "Сессия";

        public const string DisplayOperationLabel = "Операции";
        public const string DisplayOperationLabelEdit = "Редактировать";
        public const string DisplayOperationLabelDetails = "Подробнее";
        public const string DisplayOperationLabelDelete = "Удалить";
    }
}