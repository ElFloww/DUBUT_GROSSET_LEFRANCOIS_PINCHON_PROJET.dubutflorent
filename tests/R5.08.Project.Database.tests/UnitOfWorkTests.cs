using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using R5._08.Project.Database.EntityFramework.Repository;
using Moq;
using R5._08.Project.Database.Interface;
using System;
using Xunit;

namespace R5._08.Project.Database.tests
{
    public class UnitOfWorkTests
    {
        private UnitOfWork<DbContext> m_UnitOfWork;
        private readonly Mock<DbContext> m_DbContextMock;

        public UnitOfWorkTests()
        {
            m_DbContextMock = new Mock<DbContext>();
            Mock<DatabaseFacade> v_DatabaseMock = new(m_DbContextMock.Object);
            m_DbContextMock.SetupGet(p_M => p_M.Database).Returns(v_DatabaseMock.Object);
        }

        [Fact]
        public void Constructor_Should_Throw_ArgumentNullException_When_DbContext_Is_Null()
        {
            // Arrange
            DbContext v_DbContext = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new UnitOfWork<DbContext>(v_DbContext));
        }

        [Fact]
        public void Save_Should_Call_SaveChanges_Method_Of_DbContext()
        {
            // Arrange
            UnitOfWork<DbContext> v_UnitOfWork = new UnitOfWork<DbContext>(m_DbContextMock.Object);

            // Act
            v_UnitOfWork.Save();

            // Assert
            m_DbContextMock.Verify(p_M => p_M.SaveChanges(), Times.Once);
        }

        [Fact]
        public void Save_Should_Return_Number_Of_Changes_Saved()
        {
            // Arrange
            UnitOfWork<DbContext> v_Uow = new UnitOfWork<DbContext>(m_DbContextMock.Object);
            m_DbContextMock.Setup(p_D => p_D.SaveChanges()).Returns(2);

            // Act
            int v_Result = v_Uow.Save();

            // Assert
            Assert.Equal(2, v_Result);
        }
    }
}
