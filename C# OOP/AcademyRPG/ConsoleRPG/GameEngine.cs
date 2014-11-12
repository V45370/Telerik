namespace ConsoleRPG
{
    using ConsoleRPG.GameObjects.MapObjects;
    using ConsoleRPG.GameObjects;
    using ConsoleRPG.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public class GameEngine
    {
        private readonly Keyboard controller;
        private readonly IRenderer renderer;
        private readonly int milisecondsForcedDelay;
 
        private Player player;
        private Stash stash;
        private Map currentMap;

        private List<Npc> npcList;
        private NakovNPC nakov;
        
        private List<IRenderable> renderableObjects;
        private List<ICollidable> collidableObjects;

        public GameEngine(Keyboard controller, IRenderer renderer, uint milisecondsForcedDelay)
        {
            this.controller = controller;
            this.renderer = renderer;
            this.milisecondsForcedDelay = (int)milisecondsForcedDelay;
        }

        public void Run()
        {
            StartMenu.MenuAction();

            this.SetUpController();

            this.InitializeGameObjects();

            this.SetCurrentMap(currentMap);

            while ("GameIsOn" == "GameIsOn")
            {
                this.controller.ProcessInput();

                //if this returns true some menu interaction occured..
                if (ProcessColidableObjects())
                {
                    //..and we have to redraw the map after interaction finishes
                    this.SetCurrentMap(currentMap);
                }

                //only the player is activly always rendered but still call the method in case other items are added for rendering
                RenderRenderableObjects();

                Thread.Sleep(milisecondsForcedDelay);
            }
        }

        #region controller
        private void SetUpController()
        {
            this.controller.KeyPressed += (sender, eventInfo) =>
            {
                this.OnArrowPressed((sender as Keyboard).PressedKey.Key);
            };
        }

        public void OnArrowPressed(ConsoleKey pressedKey)
        {
            IMoveable objectToMove = this.player;

            bool checkOtherControls = true;

            foreach (ICollidable obj in this.collidableObjects)
            {
                if (obj.Interacting)
                {
                    checkOtherControls = false;
                    objectToMove = obj as IMoveable;
                    break;
                }
            }

            if (objectToMove == this.player)
            {
                this.renderer.DeleteObject((IRenderable)objectToMove);
            }
            
            if (pressedKey == ConsoleKey.RightArrow)
            {
                objectToMove.MoveRight();
            }
            else if (pressedKey == ConsoleKey.LeftArrow)
            {
                objectToMove.MoveLeft();
            }
            else if (pressedKey == ConsoleKey.UpArrow)
            {
                objectToMove.MoveUp();
            }
            else if (pressedKey == ConsoleKey.DownArrow)
            {
                objectToMove.MoveDown();
            }

            //other Controls Checker
            if (checkOtherControls)
            {
                if (pressedKey == ConsoleKey.I)
                {
                    player.OpenItems(this.controller);

                    this.SetCurrentMap(currentMap);
                }
                else if (pressedKey==ConsoleKey.Q)
                {
                    player.OpenQuests(this.controller);

                    this.SetCurrentMap(currentMap);
                }
                else if (pressedKey==ConsoleKey.S)
                {
                    this.player.OpenStatus(this.controller);

                    this.SetCurrentMap(currentMap);
                }
                else if (pressedKey==ConsoleKey.Escape)
                {
                    StartMenu.ExitGame();
                }
            }
        }
        #endregion

        private bool ProcessColidableObjects()
        {
            foreach (var collidableobj in this.collidableObjects)
            {
                if (collidableobj.ColisionCoordinates == this.player.ColisionCoords)
                {
                    collidableobj.RespondToCollision(this.player, this.controller);
                    return true;
                }
            }
            return false;
        }

        private void RenderRenderableObjects()
        {
            this.renderer.Render(this.player);
        }

        private void InitializeGameObjects()
        {
            this.player = GameObjectsInitializer.GeneratePlayer();

            this.stash = GameObjectsInitializer.GenerateStash();

            this.currentMap = GameObjectsInitializer.GenerateMap();

            this.npcList = GameObjectsInitializer.GenerateNPCs();

            this.nakov = GameObjectsInitializer.GenerateNakov();
            

            //adding objects for renderring
            this.renderableObjects = new List<IRenderable>();

            this.renderableObjects.Add(this.stash);

            this.renderableObjects.AddRange(this.npcList);

            this.renderableObjects.Add(this.nakov);

            this.renderableObjects.Add(this.stash);

            this.currentMap.AddList(this.renderableObjects);


            //adding interaction objects
            this.collidableObjects = new List<ICollidable>();

            this.collidableObjects.AddRange(this.npcList);

            this.collidableObjects.Add(this.nakov);

            this.collidableObjects.Add(this.stash);
        }

        private void SetCurrentMap(Map map)
        {
            this.renderer.InitializeMap(map);
            this.renderer.RenderBackground();
        }
    }
}