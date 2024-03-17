using Moq;
using ProjetForm;
using R5._08.Project.Database.Entities;
using R5._08.Project.Database.Interface;
using System;
using System.Collections.Generic;
using Xunit;
using Bogus;
using System.Linq;

namespace R5._08.Project.Forms.Tests.Forms
{
    public class ScoresFormTests
    {
        private readonly Mock<IUnitOfWork> m_UnitOfWorkMock = new();

        private ScoresForm m_ScoreForm;


        [Fact]
        public void LoadForm_WhenDatabaseExist_ShouldAddDataInTab()
        {
            // Arrange
            Faker<Scoreboard> v_ScoreBoardFaker = new Faker<Scoreboard>()
                .RuleFor(p_P => p_P.Id, p_Faker => p_Faker.Random.Int())
                .RuleFor(p_P => p_P.Name, p_Faker => p_Faker.Name.FullName())
                .RuleFor(p_P => p_P.NumberOfGames, p_Faker => p_Faker.Random.Int())
                .RuleFor(p_P => p_P.NumberOfWins, p_Faker => p_Faker.Random.Int())
                .RuleFor(p_P => p_P.AverageTime, p_Faker => p_Faker.Random.Int());

            IEnumerable<Scoreboard> v_Scoreboards = v_ScoreBoardFaker.Generate(10);

            m_ScoreForm = new ScoresForm(m_UnitOfWorkMock.Object);
            m_UnitOfWorkMock.Setup(p_Uow => p_Uow.ScoreboardRepository.GetAllScoreboards()).ReturnsAsync(v_Scoreboards);

            // Act
            m_ScoreForm.ScoresForm_Load(new object(), new EventArgs());

            // Assert
            Assert.Equal(m_ScoreForm.m_ScoresGridView.RowCount, v_Scoreboards.Count());
        }

        [Fact]
        public void LoadForm_WhenDatabaseNotExist_ShouldAddDataInTab()
        {
            // Arrange
            Faker<Scoreboard> v_ScoreBoardFaker = new Faker<Scoreboard>()
                .RuleFor(p_P => p_P.Id, p_Faker => p_Faker.Random.Int())
                .RuleFor(p_P => p_P.Name, p_Faker => p_Faker.Name.FullName())
                .RuleFor(p_P => p_P.NumberOfGames, p_Faker => p_Faker.Random.Int())
                .RuleFor(p_P => p_P.NumberOfWins, p_Faker => p_Faker.Random.Int())
                .RuleFor(p_P => p_P.AverageTime, p_Faker => p_Faker.Random.Int());

            IEnumerable<Scoreboard> v_Scoreboards = v_ScoreBoardFaker.Generate(10);

            m_ScoreForm = new ScoresForm(m_UnitOfWorkMock.Object);
            m_UnitOfWorkMock.Setup(p_Uow => p_Uow.ScoreboardRepository.GetAllScoreboards()).Throws<Exception>();


            // Act
            m_ScoreForm.ScoresForm_Load(new object(), new EventArgs());

            // Assert
            Assert.Equal(0, m_ScoreForm.m_ScoresGridView.RowCount);
        }
    }
}
