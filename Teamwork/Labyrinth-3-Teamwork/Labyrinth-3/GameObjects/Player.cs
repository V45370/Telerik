﻿namespace Labyrinth.GameObjects
{
    using System;
    using Labyrinth.Interfaces;

    /// <summary>
    /// Player class
    /// <remarks>
    /// Inhertis the Cell and IPlayer interfaces
    /// </remarks>
    /// </summary>
    public class Player : Cell, IPlayer
    {
        private Position position;
        private IMaze maze;
        private IScore score;
        private PlayerDirection direction;

        /// <summary>
        /// Player consturctor
        /// <remarks>
        /// Will call the base constructor
        /// </remarks>
        /// </summary>
        public Player() : base(Cell.PLAYER_VALUE)
        {
        }

        /// <summary>
        /// Getter and setter for the current Maze
        /// <remarks>
        /// Validates the input for null or empty value
        /// <returns>
        /// Returns the maze object with a getter
        /// </returns>
        /// </remarks>
        /// </summary>
        public IMaze Maze
        {
            get
            {
                this.CheckIfPropertyIsNull(this.maze);
                return this.maze;
            }

            set
            {
                this.CheckIfPropertyIsNull(value);
                this.maze = value;
            }
        }

        /// <summary>
        /// Getter and setter for the current Score
        /// <remarks>
        /// Validates the input for null or empty value
        /// <returns>
        /// Returns the score object with a getter
        /// </returns>
        /// </remarks>
        /// </summary>
        public IScore Score
        {
            get
            {
                this.CheckIfPropertyIsNull(this.score);
                return this.score;
            }

            set
            {
                this.CheckIfPropertyIsNull(value);
                this.score = value;
            }
        }

        /// <summary>
        /// Getter and setter for the current Command
        /// <remarks>
        /// None
        /// <returns>
        /// Utilizes automatic getter and setter
        /// </returns>
        /// </remarks>
        /// </summary>
        public PlayerCommand Command { get; set; }

        /// <summary>
        /// Getter and setter for the current PlayerMoved
        /// <remarks>
        /// None
        /// <returns>
        /// Utilizes automatic getter and private setter
        /// </returns>
        /// </remarks>
        /// </summary>
        public bool PlayerMoved { get; private set; }

        /// <summary>
        /// Getter and setter for the current Direction
        /// <remarks>
        /// Setter utilizes the Observer pattern
        /// <returns>
        /// Returns the current direction with a getter
        /// </returns>
        /// </remarks>
        /// </summary>
        private PlayerDirection Direction
        {
            get
            {
                return this.direction;
            }

            set
            {
                this.direction = value;

                // Observer pattern... player notifies himself to move when his direction is changed...
                this.Move();
            }
        }

        /// <summary>
        /// Method for console command evaluation
        /// <remarks>
        /// Can create maze, move player, show score, restart and exit
        /// </remarks>
        /// <param name="operator">
        /// Accepts a string for further command parsing
        /// </param>
        /// </summary>
        public void ExecuteCommand(string @operator)
        {
            switch (@operator)
            {
                case "small":
                    this.Command = PlayerCommand.CreateSmallMaze;
                    break;
                case "medium":
                    this.Command = PlayerCommand.CreateMediumMaze;
                    break;
                case "large":
                    this.Command = PlayerCommand.CreateLargeMaze;
                    break;
                case "d":
                    this.Direction = PlayerDirection.Down;
                    break;
                case "u":
                    this.Direction = PlayerDirection.Up;
                    break;
                case "r":
                    this.Direction = PlayerDirection.Right;
                    break;
                case "l":
                    this.Direction = PlayerDirection.Left;
                    break;
                case "top":
                    this.Command = PlayerCommand.PrintTopScores;
                    break;
                case "restart":
                    this.Command = PlayerCommand.Restart;
                    break;
                case "exit":
                    this.Command = PlayerCommand.Exit;
                    break;
                default:
                    this.Command = PlayerCommand.InvalidCommand;
                    this.PlayerMoved = false;
                    break;
            }
        }

        /// <summary>
        /// This method checks whether the player has exited the maze
        /// <remarks>
        /// Will check maze limits and player position
        /// <returns>
        /// Returns TRUE if player is outside of maze
        /// </returns>
        /// </remarks>
        /// </summary>
        public bool IsOutOfTheMaze()
        {
            this.position = this.Maze.PlayerPosition;

            if (this.position.X == 0 ||
                this.position.X == this.Maze.Rows - 1 ||
                this.position.Y == 0 ||
                this.position.Y == this.Maze.Cols - 1)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Move method. Can be invoked by the observer pattern
        /// <remarks>
        /// Can move in directions set as in the enumerator. Will check for invalid move if the player's way is blocked
        /// </remarks>
        /// </summary>
        private void Move()
        { 
            this.PlayerMoved = false;
            this.position = this.Maze.PlayerPosition;
            this.Maze[this.position.X, this.position.Y].Value = Cell.EMPTY_CELL;

            switch (this.Direction)
            {
                case PlayerDirection.Up:
                    this.MoveUp();

                    break;
                case PlayerDirection.Down:
                    this.MoveDown();

                    break;
                case PlayerDirection.Left:
                    this.MoveLeft();

                    break;
                case PlayerDirection.Right:
                    this.MoveRight();

                    break;
            }

            if (!this.PlayerMoved)
            {
                this.Command = PlayerCommand.InvalidMove;
            }
            else
            {
                this.Score.Moves++;
            }
        }

        /// <summary>
        /// Move UP method
        /// </summary>
        private void MoveUp()
        {
            if (this.Maze[this.position.X - 1, this.position.Y].IsEmpty)
            {
                this.position.X--;
                this.PlayerMoved = true;
            }
        }

        /// <summary>
        /// Move DOWN method
        /// </summary>
        private void MoveDown()
        {
            if (this.Maze[this.position.X + 1, this.position.Y].IsEmpty)
            {
                this.position.X++;
                this.PlayerMoved = true;
            }
        }

        /// <summary>
        /// Move LEFT method
        /// </summary>
        private void MoveLeft()
        {
            if (this.Maze[this.position.X, this.position.Y - 1].IsEmpty)
            {
                this.position.Y--;
                this.PlayerMoved = true;
            }
        }

        /// <summary>
        /// Move RIGHT method
        /// </summary>
        private void MoveRight()
        {
            if (this.Maze[this.position.X, this.position.Y + 1].IsEmpty)
            {
                this.position.Y++;
                this.PlayerMoved = true;
            }
        }

        /// <summary>
        /// Defensive method for rejecting wrong values
        /// <remarks>
        /// Will check value for null
        /// <returns>
        /// Will throw a NullReferenceException if supplied value is null
        /// </returns>
        /// </remarks>
        /// </summary>
        private void CheckIfPropertyIsNull(object obj)
        {
            if (obj == null)
            {
                throw new NullReferenceException("This player property cannot be null!");
            }
        }
    }
}