using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataLayer.ViewModels.DashboardViewModels;

namespace DataLayer.Repositories
{
    public class DashboardRepository
    {
        //private IDbConnection conn = new SqlConnection(
        //    ConfigurationManager.ConnectionStrings["DefaultConnection"]
        //    .ConnectionString);

        public async Task<IEnumerable<SidebarVM>> GetSidebars(string ulpId)
        {
            using (var db = new SqlConnection(
                     ConfigurationManager.ConnectionStrings["DefaultConnection"]
                     .ConnectionString))
            {
                await db.OpenAsync();                

                DynamicParameters p = new DynamicParameters();
                p.Add("@ulpId", ulpId);

                IEnumerable<SidebarVM> sidebar = await db.QueryAsync<SidebarVM>("sp_GetMemberUserNavConfig", p, commandType: CommandType.StoredProcedure);

                return sidebar;
            }
        }

        public async Task<IEnumerable<ActionBarVM>> GetActionBars(string ulpId)
        {
            using (var db = new SqlConnection(
                     ConfigurationManager.ConnectionStrings["DefaultConnection"]
                     .ConnectionString))
            {
                await db.OpenAsync();              

                DynamicParameters p = new DynamicParameters();
                p.Add("@ulpId", ulpId);

                IEnumerable<ActionBarVM> actionbar = await db.QueryAsync<ActionBarVM>("Sp_GetUserActionbars", p, commandType: CommandType.StoredProcedure);

                return actionbar;
            }
        }

        public async Task<IEnumerable<UserDetailsVM>> GetUserDetailedInfo(string ulpId)
        {
            using (var db = new SqlConnection(
                        ConfigurationManager.ConnectionStrings["DefaultConnection"]
                        .ConnectionString))
            {
                await db.OpenAsync();
                
                DynamicParameters p = new DynamicParameters();
                p.Add("@ulpId", ulpId);

                IEnumerable<UserDetailsVM> userDetails = await db.QueryAsync<UserDetailsVM>("Sp_GetUserInformationByUserId", p, commandType: CommandType.StoredProcedure);

                var result = userDetails.AsEnumerable();

                return result;

            }
        }

        public async Task<IEnumerable<MembersVM>> GetMembers(string ulpId)
        {
            using (var db = new SqlConnection(
                        ConfigurationManager.ConnectionStrings["DefaultConnection"]
                        .ConnectionString))
            {
                await db.OpenAsync();

                DynamicParameters p = new DynamicParameters();
                p.Add("@ulpId", ulpId);

                IEnumerable<MembersVM> members = await db.QueryAsync<MembersVM>("Sp_GetUserMembersList", p, commandType: CommandType.StoredProcedure);

                return members;

            }
        }
    }
}