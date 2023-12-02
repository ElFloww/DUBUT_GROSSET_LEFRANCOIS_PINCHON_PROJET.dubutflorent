using Xunit;
using static R5._08.Project.Database.DatabaseConnection;

namespace R5._08.Project.Database.tests
{
    public class DatabaseConnectionTests
    {
        [Fact]
        public void OpenCloseDatabaseConnection_WhenDatabaseIsAvaiable_ShouldConnectCloseToTheDatabase()
        {
            bool v_ResultOpenConnection = OpenConnection("server = 79.87.121.17; uid = basetest; pwd = 337cTwYMpQd7g3");
            bool v_ResultCloseConnection = CloseConnection();
            Assert.True(v_ResultOpenConnection);
            Assert.True(v_ResultCloseConnection);
        }
        [Fact]
        public void OpenCloseDatabaseConnection_WhenDatabaseIsNotAvaiable_ShouldNotConnectToDatabase()
        {
            bool v_ResultOpenConnection = OpenConnection(string.Empty);
            bool v_ResultCloseConnection = CloseConnection();
            Assert.False(v_ResultOpenConnection);
            Assert.False(v_ResultCloseConnection);
        }
    }
}
