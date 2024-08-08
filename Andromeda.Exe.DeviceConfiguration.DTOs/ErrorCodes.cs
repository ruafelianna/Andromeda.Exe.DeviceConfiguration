namespace Andromeda.Exe.DeviceConfiguration.DTOs
{
    public enum ErrorCodes
    {
        //AppInstance codes

        AppInstanceNotFoundByGuid = 1001,

        AppInstanceGuidNotUnique = 1002,

        NoOnlineToken = 1003,

        IncorrectOnlineToken = 1004,

        AppInstanceConcurrencyError = 1005,

        LoginRecordNotFoundById = 1006,
    }
}
