using Moq;
using ProjetForm;
using R5._08.Project.Database.Interface;
using System;
using Xunit;
namespace R5._08.Project.Forms.Tests.Forms
{
    public class HomeFormTests
    {
        private readonly Mock<IUnitOfWork> m_UnitOfWorkMock = new();

        private HomeForm m_HomeForm;

        [Fact]
        public void ClickOnExit_ShouldCloseActualForm()
        {
            // Arrange
            m_HomeForm = new HomeForm(m_UnitOfWorkMock.Object);

            // Act
            m_HomeForm.BtnHomeQuit_Click(new object(), new EventArgs());

            // Assert
            Assert.False(m_HomeForm.Visible);
        }
    }
}
