using ProjetForm;
using System;
using System.Drawing;
using System.Windows.Forms;
using Xunit;
using Bogus;
using Moq;
using R5._08.Project.Database.Entities;
using R5._08.Project.Forms.Models;
using R5._08.Project.Database.Interface;

namespace R5._08.Project.Forms.Tests
{
    public class PlateauFormTests
    {
        private readonly Mock<IUnitOfWork> m_UnitOfWorkMock = new();

        [Fact]
        public void AddOnePawnOnBoard_WhenEverythingIsOk_ShouldAddThePawn()
        {
            // Arrange
            Faker v_Faker = new();
            string v_Player1 = v_Faker.Person.FullName;
            string v_Player2 = v_Faker.Person.FullName;
            Puissance4 v_Puissance4 = new();
            PlateauForm v_PlateauForm = new(v_Puissance4, m_UnitOfWorkMock.Object);
            PictureBox v_PlayerPawn = v_Puissance4.CreatePawn();
            // Act
            v_PlateauForm.AddPawnOnBoard(v_PlayerPawn, 1, 1);

            // Assert
            Assert.Single(v_PlateauForm.m_PlateauJeu.Controls);
        }
        [Fact]
        public void AddTwoPawnOnBoard_WhenEachPlayerPlay_ShouldAddTwoPawns()
        {
            // Arrange
            Faker v_Faker = new();
            string v_Player1 = v_Faker.Person.FullName;
            string v_Player2 = v_Faker.Person.FullName;
            Puissance4 v_Puissance4 = new();
            PlateauForm v_PlateauForm = new(v_Puissance4, m_UnitOfWorkMock.Object);
            PictureBox v_PlayerPawn1 = v_Puissance4.CreatePawn();
            PictureBox v_PlayerPawn2 = v_Puissance4.CreatePawn();

            // Act

            //Pawn 1
            v_PlateauForm.AddPawnOnBoard(v_PlayerPawn1, 1, 1);

            //Pawn 2
            v_PlateauForm.AddPawnOnBoard(v_PlayerPawn2, 2, 1);

            // Assert
            Assert.Equal(2, v_PlateauForm.m_PlateauJeu.Controls.Count);
        }

        [Fact]
        public void EnableEndScreen_WhenPlayerDraw_ShouldEnableEndScreenWithWinMessage()
        {
            // Arrange
            Faker v_Faker = new();
            string v_Player1 = v_Faker.Person.FullName;
            string v_Player2 = v_Faker.Person.FullName;
            Puissance4 v_Puissance4 = new();
            PlateauForm v_PlateauForm = new(v_Puissance4, m_UnitOfWorkMock.Object);

            // Act
            v_PlateauForm.EnableEndScreen(v_Player1, false);

            // Assert

            Assert.Equal($"{v_Player1} a gagné !", v_PlateauForm.m_LblWinner.Text);
        }

        [Fact]
        public void EnableEndScreen_WhenNoPlayerDraw_ShouldEnableEndScreenWithEqualityMessage()
        {
            // Arrange
            Faker v_Faker = new();
            string v_Player1 = v_Faker.Person.FullName;
            string v_Player2 = v_Faker.Person.FullName;
            Puissance4 v_Puissance4 = new();
            PlateauForm v_PlateauForm = new(v_Puissance4, m_UnitOfWorkMock.Object);

            // Act
            v_PlateauForm.EnableEndScreen(v_Player1, true);

            // Assert

            Assert.Equal("Égalité !", v_PlateauForm.m_LblWinner.Text);
        }

        [Fact]
        public void PlayPawnOnSevenColumns_ShoudAddSevenPawn()
        {
            // Arrange
            Faker v_Faker = new();
            string v_Player1 = v_Faker.Person.FullName;
            string v_Player2 = v_Faker.Person.FullName;
            Puissance4 v_Puissance4 = new();
            PlateauForm v_PlateauForm = new(v_Puissance4, m_UnitOfWorkMock.Object);

            // Act for each button
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol1)
            }, EventArgs.Empty);
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol2)
            }, EventArgs.Empty);
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol3)
            }, EventArgs.Empty);
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol4)
            }, EventArgs.Empty);
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol5)
            }, EventArgs.Empty);
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol6)
            }, EventArgs.Empty);
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol7)
            }, EventArgs.Empty);

            // Assert
            Assert.Equal(7, v_PlateauForm.m_PlateauJeu.Controls.Count);
        }

        [Fact]
        public void PlayPawn_WhenAPlayerWin_ShoudEndScreen()
        {
            // Arrange
            Faker v_Faker = new();
            Puissance4 v_Puissance4 = new();
            v_Puissance4.m_Joueur1 = v_Faker.Person.FullName;
            v_Puissance4.m_Joueur2 = v_Faker.Person.FullName;
            PlateauForm v_PlateauForm = new(v_Puissance4, m_UnitOfWorkMock.Object);

            v_PlateauForm.PlateauForm_Load(new object(), EventArgs.Empty);

            // Act
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol1)
            }, EventArgs.Empty);
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol2)
            }, EventArgs.Empty);
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol1)
            }, EventArgs.Empty);
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol2)
            }, EventArgs.Empty);
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol1)
            }, EventArgs.Empty);
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol2)
            }, EventArgs.Empty);
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol1)
            }, EventArgs.Empty);

            Assert.Equal($"{v_Puissance4.m_Joueur1} a gagné !", v_PlateauForm.m_LblWinner.Text);
        }


        [Fact]
        public void PlayPawn_WhenPartyDraw_ShoudEndScreen()
        {
            // Arrange
            Faker v_Faker = new();
            Puissance4 v_Puissance4 = new()
            {
                m_Joueur1 = v_Faker.Person.FullName,
                m_Joueur2 = v_Faker.Person.FullName
            };
            PlateauForm v_PlateauForm = new(v_Puissance4, m_UnitOfWorkMock.Object);

            v_PlateauForm.PlateauForm_Load(new object(), EventArgs.Empty);

            // Act
            #region add all pawn
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol1)
            }, EventArgs.Empty);
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol2)
            }, EventArgs.Empty);
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol3)
            }, EventArgs.Empty);
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol4)
            }, EventArgs.Empty);
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol5)
            }, EventArgs.Empty);
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol6)
            }, EventArgs.Empty);
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol7)
            }, EventArgs.Empty);
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol1)
            }, EventArgs.Empty);
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol2)
            }, EventArgs.Empty);
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol3)
            }, EventArgs.Empty);
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol4)
            }, EventArgs.Empty);
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol5)
            }, EventArgs.Empty);
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol6)
            }, EventArgs.Empty);
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol7)
            }, EventArgs.Empty);
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol1)
            }, EventArgs.Empty);
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol2)
            }, EventArgs.Empty);
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol3)
            }, EventArgs.Empty);
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol4)
            }, EventArgs.Empty);
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol5)
            }, EventArgs.Empty);
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol6)
            }, EventArgs.Empty);
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol7)
            }, EventArgs.Empty);


            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol2)
            }, EventArgs.Empty);
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol2)
            }, EventArgs.Empty);

            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol4)
            }, EventArgs.Empty);
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol4)
            }, EventArgs.Empty);

            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol6)
            }, EventArgs.Empty);
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol6)
            }, EventArgs.Empty);

            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol6)
            }, EventArgs.Empty);
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol7)
            }, EventArgs.Empty);
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol7)
            }, EventArgs.Empty);
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol5)
            }, EventArgs.Empty);
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol5)
            }, EventArgs.Empty);

            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol3)
            }, EventArgs.Empty);
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol3)
            }, EventArgs.Empty);

            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol1)
            }, EventArgs.Empty);
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol1)
            }, EventArgs.Empty);
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol1)
            }, EventArgs.Empty);
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol2)
            }, EventArgs.Empty);
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol3)
            }, EventArgs.Empty);
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol4)
            }, EventArgs.Empty);
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol5)
            }, EventArgs.Empty);
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol7)
            }, EventArgs.Empty);

            #endregion

            // Assert
            Assert.Equal("Égalité !", v_PlateauForm.m_LblWinner.Text);
        }

        [Fact]
        public void btnPlateauAbandon_WhenUserClickOnButton_ShoudEnableEndScreenWithAbandon()
        {
            // Arrange
            Faker v_Faker = new();
            Puissance4 v_Puissance4 = new()
            {
                m_Joueur1 = v_Faker.Person.FullName,
                m_Joueur2 = v_Faker.Person.FullName
            };
            PlateauForm v_PlateauForm = new(v_Puissance4, m_UnitOfWorkMock.Object);

            v_PlateauForm.PlateauForm_Load(new object(), EventArgs.Empty);

            // Act
            v_PlateauForm.btnPlateauAbandon_Click(new object(), EventArgs.Empty);

            // Assert
            Assert.Equal($"{v_Puissance4.m_Joueur2} a gagné !", v_PlateauForm.m_LblWinner.Text);
        }

        [Fact]
        public void btnAddPlayer_WhenUserDoesNotExistInDatabase_ShoudCreateTheUser()
        {
            // Arrange
            Faker v_Faker = new();
            Puissance4 v_Puissance4 = new()
            {
                m_Joueur1 = v_Faker.Person.FullName,
                m_Joueur2 = v_Faker.Person.FullName
            };
            PlateauForm v_PlateauForm = new(v_Puissance4, m_UnitOfWorkMock.Object);

            m_UnitOfWorkMock.Setup(p_U => p_U.ScoreboardRepository.GetScoreboardByName(It.IsAny<string>()));
            m_UnitOfWorkMock.Setup(p_U => p_U.ScoreboardRepository.AddScoreboards(It.IsAny<Scoreboard>())).Verifiable();
            m_UnitOfWorkMock.Setup(p_U => p_U.Save());

            v_PlateauForm.PlateauForm_Load(new object(), EventArgs.Empty);

            // Act
            _ = v_PlateauForm.AddPlayer(true, v_Puissance4.m_Joueur1);

            // Assert
            m_UnitOfWorkMock.Verify(p_DC => p_DC.ScoreboardRepository.GetScoreboardByName(It.IsAny<string>()), Times.Once);
            m_UnitOfWorkMock.Verify(p_DC => p_DC.ScoreboardRepository.AddScoreboards(It.IsAny<Scoreboard>()), Times.Once);
            m_UnitOfWorkMock.Verify(p_DC => p_DC.Save(), Times.Once);
        }

        [Fact]
        public void btnAddPlayer_WhenUserExistInDatabase_ShoudUpdateTheUser()
        {
            // Arrange
            Faker v_Faker = new();
            Puissance4 v_Puissance4 = new()
            {
                m_Joueur1 = v_Faker.Person.FullName,
                m_Joueur2 = v_Faker.Person.FullName
            };
            PlateauForm v_PlateauForm = new(v_Puissance4, m_UnitOfWorkMock.Object);

            m_UnitOfWorkMock.Setup(p_U => p_U.ScoreboardRepository.GetScoreboardByName(It.IsAny<string>())).ReturnsAsync(new Scoreboard() { Id = v_Faker.Random.Int(), Name = v_Puissance4.m_Joueur1, AverageTime = v_Faker.Random.Int(), NumberOfGames = v_Faker.Random.Int(), NumberOfWins = v_Faker.Random.Int() });
            m_UnitOfWorkMock.Setup(p_U => p_U.ScoreboardRepository.UpdateScoreboards(It.IsAny<Scoreboard>())).Verifiable();
            m_UnitOfWorkMock.Setup(p_U => p_U.Save());

            v_PlateauForm.PlateauForm_Load(new object(), EventArgs.Empty);

            // Act
            _ = v_PlateauForm.AddPlayer(true, v_Puissance4.m_Joueur1);

            // Assert
            m_UnitOfWorkMock.Verify(p_DC => p_DC.ScoreboardRepository.GetScoreboardByName(It.IsAny<string>()), Times.Once);
            m_UnitOfWorkMock.Verify(p_DC => p_DC.ScoreboardRepository.UpdateScoreboards(It.IsAny<Scoreboard>()), Times.Once);
            m_UnitOfWorkMock.Verify(p_DC => p_DC.Save(), Times.Once);
        }

        [Fact]
        public void PlayPawn_WhenItsVSEasyIa_IAShouldPlacePawn()
        {
            // Arrange
            Faker v_Faker = new();
            Puissance4 v_Puissance4 = new()
            {
                m_Joueur1 = v_Faker.Person.FullName,
                m_Joueur2 = v_Faker.Person.FullName
            };
            PlateauForm v_PlateauForm = new(v_Puissance4, m_UnitOfWorkMock.Object);
            //Set bot difficulty to easy
            v_Puissance4.m_difficulty = 0;

            v_PlateauForm.PlateauForm_Load(new object(), EventArgs.Empty);

            // Act
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol2)
            }, EventArgs.Empty);

            // Assert
            Assert.Equal(2, v_Puissance4.m_NbPawn);
        }

        [Fact]
        public void Play_WhenItsVSHARDIa_IAShouldWinIn5Rounds()
        {
            // Arrange
            Faker v_Faker = new();
            Puissance4 v_Puissance4 = new()
            {
                m_Joueur1 = v_Faker.Person.FullName,
                m_Joueur2 = "IA Difficile",
                //Set bot difficulty
                m_difficulty = 2,
            };
            PlateauForm v_PlateauForm = new(v_Puissance4, m_UnitOfWorkMock.Object);

            v_PlateauForm.PlateauForm_Load(new object(), EventArgs.Empty);

            // Act
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol1)
            }, EventArgs.Empty);
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol1)
            }, EventArgs.Empty);
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol1)
            }, EventArgs.Empty);
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol1)
            }, EventArgs.Empty);
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol1)
            }, EventArgs.Empty);

            // Assert
            Assert.Equal(10, v_Puissance4.m_NbPawn);
            Assert.Equal($"{v_Puissance4.m_Joueur2} a gagné !", v_PlateauForm.m_LblWinner.Text);
        }


        [Fact]
        public void Play_WhenItsVSMediumIaAndWhenIaStart_ShouldPlaceThreePawnInOneRound()
        {
            // Arrange
            Faker v_Faker = new();
            Puissance4 v_Puissance4 = new()
            {
                m_Joueur1 = v_Faker.Person.FullName,
                m_Joueur2 = "IA Normale",
                m_IaStart = true,
                m_difficulty = 1
        };
            PlateauForm v_PlateauForm = new(v_Puissance4, m_UnitOfWorkMock.Object);
            //Set bot difficulty
            
            

            v_PlateauForm.PlateauForm_Load(new object(), EventArgs.Empty);

            // Act
            v_PlateauForm.buttonColonne_Click(new Button()
            {
                Name = nameof(v_PlateauForm.m_BtnCol1)
            }, EventArgs.Empty);

            // Assert
            Assert.Equal(3, v_Puissance4.m_NbPawn);
        }
    }
}
