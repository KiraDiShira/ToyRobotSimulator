using Moq;
using NUnit.Framework;
using System;
using ToyRobotSimulator.ConsoleApp.BusinessLogic.CommandsFileReader;

namespace ToyRobotSimulator.Fixtures
{
    public class CommandsReaderFixtures
    {
        [Test]
        public void GetCommands_ReadFileWithOneCommand_GetOneCommand()
        {
            //Arrange           
            var commandsFile = @"PLACE 1,1,NORTH";
            var mockFileReader = new Mock<IFileReader>();
            mockFileReader.Setup(mockFileReader => mockFileReader.ReadAllText(It.IsAny<string>())).Returns(commandsFile);
            CommandsReader commandsReader = new CommandsReader(mockFileReader.Object);

            //Act
            string[] commands = commandsReader.GetCommands("filePath");

            //Assert
            Assert.AreEqual(1, commands.Length);
            Assert.AreEqual("PLACE 1,1,NORTH", commands[0]);
        }

        [Test]
        public void GetCommands_ReadFileWithTwoCommands_GetTwoCommands()
        {
            //Arrange           
            var commandsFile = @"PLACE 1,1,NORTH
MOVE";
            var mockFileReader = new Mock<IFileReader>();
            mockFileReader.Setup(mockFileReader => mockFileReader.ReadAllText(It.IsAny<string>())).Returns(commandsFile);
            CommandsReader commandsReader = new CommandsReader(mockFileReader.Object);

            //Act
            string[] commands = commandsReader.GetCommands("filePath");

            //Assert
            Assert.AreEqual(2, commands.Length);
            Assert.AreEqual("PLACE 1,1,NORTH", commands[0]);
            Assert.AreEqual("MOVE", commands[1]);
        }

        [Test]
        public void GetCommands_NoFile_ThrowsException()
        {
            //Arrange
            var mockFileReader = new Mock<IFileReader>();         
            CommandsReader commandsReader = new CommandsReader(mockFileReader.Object);

            //Act and Assert
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => commandsReader.GetCommands(null));
            Assert.AreEqual("Value cannot be null. (Parameter 'filePath')", exception.Message);
        }
    }
}
