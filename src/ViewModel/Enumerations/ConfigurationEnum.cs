namespace ViewModel.Enumerations
{
    public static class ConfigurationEnum
    {
        public static string BaseConn = "Server=tcp:srvtest.database.windows.net,1433;Initial Catalog=testdb;Persist Security Info=False;User ID=admindb;Password=Pass1234;MultipleActiveResultSets=False; Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
        public static string BaseConnAudit = "Server=tcp:srvtest.database.windows.net,1433;Initial Catalog=testdb;Persist Security Info=False;User ID=admindb;Password=Pass1234;MultipleActiveResultSets=False; Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
        public static string DbUpdateException = "Hubo un error al actualizar el modelo o el modelo NO tiene elementos para modificar";
        public static string DbError = "Error en el motor de Base de Datos";
        public static string OwnError = "Error controlado o regla de negocio";
        public static string FatalError = "Error fatal";
        public static string AdminError = "Error fatal. Por favor contactese con el administrador";
    }
}
