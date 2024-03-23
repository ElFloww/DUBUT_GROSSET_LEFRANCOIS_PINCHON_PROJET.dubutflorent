using Bogus;
using Moq;
using ProjetForm;
using R5._08.Project.Database.Interface;
using System;
using System.Windows.Forms;
using Xunit;

namespace R5._08.Project.Forms.Tests.Forms
{
    public class GameModeFormTests
    {
        private readonly Mock<IUnitOfWork> m_UnitOfWorkMock = new();
        private readonly Faker m_Faker = new();

        private GameModeForm m_GameModeForm;

        [Fact]
        public void CheckPseudoPlayerVsPlayer_WhenTwoPseudosAreCorrect_ShouldReturnTrue()
        {
            // Arrange
            m_GameModeForm = new(m_UnitOfWorkMock.Object);

            // Act
            m_GameModeForm.m_InputPseudoPlayer1.Text = m_Faker.Name.FirstName();
            m_GameModeForm.m_InputPseudoPlayer2.Text = m_Faker.Name.FirstName();

            // Assert
            Assert.True(m_GameModeForm.CheckPseudoPlayerVSPlayer());
        }

        [Fact]
        public void CheckPseudoPlayerVsPlayer_WhenTwiceAreLong_ShouldReturnFalse()
        {
            // Arrange
            m_GameModeForm = new(m_UnitOfWorkMock.Object);

            // Act
            m_GameModeForm.m_InputPseudoPlayer1.Text = m_Faker.Lorem.Sentences(10);
            m_GameModeForm.m_InputPseudoPlayer2.Text = m_Faker.Lorem.Sentences(10);

            // Assert
            Assert.False(m_GameModeForm.CheckPseudoPlayerVSPlayer());
        }

        [Fact]
        public void CheckPseudoPlayerVsPlayer_WhenTwiceAreShort_ShouldReturnFalse()
        {
            // Arrange
            m_GameModeForm = new(m_UnitOfWorkMock.Object);

            // Act
            m_GameModeForm.m_InputPseudoPlayer1.Text = string.Empty;
            m_GameModeForm.m_InputPseudoPlayer2.Text = string.Empty;

            // Assert
            Assert.False(m_GameModeForm.CheckPseudoPlayerVSPlayer());
        }

        [Fact]
        public void CheckPseudoPlayerVsPlayer_WhenTwiceAreCorrect_ShouldReturnTrue()
        {
            // Arrange
            m_GameModeForm = new(m_UnitOfWorkMock.Object);

            // Act
            m_GameModeForm.m_InputPseudoPlayer1.Text = m_Faker.Random.String(10);
            m_GameModeForm.m_InputPseudoPlayer2.Text = m_Faker.Random.String(10);

            // Assert
            Assert.True(m_GameModeForm.CheckPseudoPlayerVSPlayer());
        }

        [Fact]
        public void InputPseudo_WhenInputIsOnDefault_ShouldClearTheInput()
        {
            // Arrange
            m_GameModeForm = new(m_UnitOfWorkMock.Object);

            // Act
            m_GameModeForm.InputPseudoPlayer1_Enter(new object(), new EventArgs());
            m_GameModeForm.InputPseudoPlayer2_Enter(new object(), new EventArgs());
            m_GameModeForm.InputPseudoPlayer_Enter(new object(), new EventArgs());

            // Assert
            Assert.Equal(m_GameModeForm.m_InputPseudoPlayer1.Text, string.Empty);
            Assert.Equal(m_GameModeForm.m_InputPseudoPlayer2.Text, string.Empty);
            Assert.Equal(m_GameModeForm.m_InputPseudoPlayer.Text, string.Empty);
        }

        
        [Fact]
        public void CheckPseudoPlayerVSAi_WhenPseudoAreShort_ShouldReturnFalse()
        {
            // Arrange
            m_GameModeForm = new(m_UnitOfWorkMock.Object);
            m_GameModeForm.m_InputPseudoPlayer.Text = string.Empty;

            // Act
            bool v_Result = m_GameModeForm.CheckPseudoPlayerVSAi();

            // Assert
            Assert.False(v_Result);
        }

        [Fact]
        public void CheckPseudoPlayerVSAi_WhenPseudoAreLong_ShouldReturnFalse()
        {
            // Arrange
            m_GameModeForm = new(m_UnitOfWorkMock.Object);
            m_GameModeForm.m_InputPseudoPlayer.Text = m_Faker.Lorem.Sentences(10);

            // Act
            bool v_Result = m_GameModeForm.CheckPseudoPlayerVSAi();

            // Assert
            Assert.False(v_Result);
        }

        [Fact]
        public void CheckPseudoPlayerVSAi_WhenPseudoAreCorrect_ShouldReturnTrue()
        {
            // Arrange
            m_GameModeForm = new(m_UnitOfWorkMock.Object);
            m_GameModeForm.m_InputPseudoPlayer.Text = m_Faker.Name.FirstName();

            // Act
            bool v_Result = m_GameModeForm.CheckPseudoPlayerVSAi();

            // Assert
            Assert.True(v_Result);
        }
    }
}
