using System.Linq;
using MOROPO.Framework.Guama.Core.Security.Common.Persistence.ORM.EF.Extensions;

namespace MOROPO.ASISTEC.Web.Olupin.Helpers
{
    public class DataInitializationHelper : Framework.Guama.Core.Persistence.ORM.EF.Helpers.Facade.IDataInitializationHelper
    {
        public void InitialiseData(Microsoft.EntityFrameworkCore.DbContext dbContext)
        {
            var permissionDbSet = dbContext.Set<Framework.Guama.Core.Security.Common.Persistence.Entities.Permission>();

            if (!permissionDbSet.Any(role => role.Code.Equals(Constants.Authorization.TraceViewerPermission)))
            {
                permissionDbSet.Add(Constants.Authorization.TraceViewerPermission.ToPermissionEntity());
            }

            #region Ilustration

            if (!permissionDbSet.Any(item => item.Code.Equals(Constants.Authorization.IlustrationViewerPermission)))
            {
                permissionDbSet.Add(Constants.Authorization.IlustrationViewerPermission.ToPermissionEntity(Constants.Authorization.IlustrationManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(Constants.Authorization.IlustrationCreatorPermission)))
            {
                permissionDbSet.Add(Constants.Authorization.IlustrationCreatorPermission.ToPermissionEntity(Constants.Authorization.IlustrationManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(Constants.Authorization.IlustrationEditorPermission)))
            {
                permissionDbSet.Add(Constants.Authorization.IlustrationEditorPermission.ToPermissionEntity(Constants.Authorization.IlustrationManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(Constants.Authorization.IlustrationRemoverPermission)))
            {
                permissionDbSet.Add(Constants.Authorization.IlustrationRemoverPermission.ToPermissionEntity(Constants.Authorization.IlustrationManagementPermissionGroup));
            }

            #endregion

            #region TextBlock

            if (!permissionDbSet.Any(item => item.Code.Equals(Constants.Authorization.TextBlockViewerPermission)))
            {
                permissionDbSet.Add(Constants.Authorization.TextBlockViewerPermission.ToPermissionEntity(Constants.Authorization.TextBlockManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(Constants.Authorization.TextBlockCreatorPermission)))
            {
                permissionDbSet.Add(Constants.Authorization.TextBlockCreatorPermission.ToPermissionEntity(Constants.Authorization.TextBlockManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(Constants.Authorization.TextBlockEditorPermission)))
            {
                permissionDbSet.Add(Constants.Authorization.TextBlockEditorPermission.ToPermissionEntity(Constants.Authorization.TextBlockManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(Constants.Authorization.TextBlockRemoverPermission)))
            {
                permissionDbSet.Add(Constants.Authorization.TextBlockRemoverPermission.ToPermissionEntity(Constants.Authorization.TextBlockManagementPermissionGroup));
            }

            #endregion

            if (dbContext is Framework.Guama.Core.Persistence.ORM.EF.Context.Contract.ITraceableDbContext)
            {
                ((Framework.Guama.Core.Persistence.ORM.EF.Context.Contract.ITraceableDbContext)dbContext).SaveChanges("system");
            }
            else
            {
                dbContext.SaveChanges();
            }
        }
    }
}
