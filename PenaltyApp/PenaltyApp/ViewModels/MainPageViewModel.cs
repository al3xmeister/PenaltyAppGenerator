using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PenaltyApp.Annotations;
using Xamarin.Forms;

namespace PenaltyApp.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private Direction _direction;
        private Height _height;
        private Position _position;
        private bool _isBusy;
        private string _arrowImageSource;
        private string _imageSource;
        private bool _hitSevenForPosition;
        private bool _hitSevenForHeight;

        public Position Position
        {
            get => _position;
            set
            {
                if (value == _position) return;
                _position = value;
                OnPropertyChanged();
            }
        }

        public Height Height
        {
            get => _height;
            set
            {
                if (value == _height) return;
                _height = value;
                OnPropertyChanged();
            }
        }

        public Direction Direction
        {
            get => _direction;
            set
            {
                if (value == _direction) return;
                _direction = value;
                OnPropertyChanged();
            }
        }

        public bool Panenka
        {
            get
            {
                return (HitSevenForHeight || HitSevenForPosition);
            }
        }

        public bool HitSevenForPosition
        {
            get => _hitSevenForPosition;
            set
            {
                if (value == _hitSevenForPosition) return;
                _hitSevenForPosition = value;
                OnPropertyChanged();
            }
        }

        public bool HitSevenForHeight
        {
            get => _hitSevenForHeight;
            set
            {
                if (value == _hitSevenForHeight) return;
                _hitSevenForHeight = value;
                OnPropertyChanged();
            }
        }

        public string ImageSource
        {
            get => _imageSource;
            set
            {
                if (value == _imageSource) return;
                _imageSource = value;
                OnPropertyChanged();
            }
        }

        public string ArrowImageSource
        {
            get => _arrowImageSource;
            set
            {
                if (value == _arrowImageSource) return;
                _arrowImageSource = value;
                OnPropertyChanged();
            }
        }

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                if (value == _isBusy) return;
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        public Command ButtonCmd { get; set; }

        public MainPageViewModel()
        {
            ButtonCmd = new Command(GetValues);
            this.Position = Position.Unset;
            this.Direction = Direction.Unset;
            this.Height = Height.Unset;
            this.ImageSource = "Resources/football.jpg";
        }

        private void GetValues()
        {
            IsBusy = true;
            GetPosition();
            GetHeight();
            GetDirection();

            if (Panenka)
            {
                ImageSource = "Resources/panenka.png";
            }
            else
            {
                switch (Position)
                {
                    case Position.Left when Height == Height.Low:

                        {
                            this.ImageSource = "Resources/leftbottom.png";
                            break;
                        }

                    case Position.Left when Height == Height.High:

                        {
                            this.ImageSource = "Resources/lefttop.png";
                            break;

                        }


                    case Position.Center when Height == Height.Low:

                        {
                            this.ImageSource = "Resources/centerbottom.png";
                            break;
                        }

                    case Position.Center when Height == Height.High:

                        {
                            this.ImageSource = "Resources/centerup.png";
                            break;

                        }

                    case Position.Right when Height == Height.Low:

                        {
                            this.ImageSource = "Resources/righttop.png";
                            break;
                        }

                    case Position.Right when Height == Height.High:

                        {
                            this.ImageSource = "Resources/rightbottom.png";
                            break;

                        }
                }
            }

            //add: statistics depending on weak foot
            //add vision arrow
            //add to source control
            //remove IsBusy

            IsBusy = false;
        }

        private void GetPosition()
        {
            Random rnd = new Random();
            int dice = rnd.Next(1, 18);

            switch (dice)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                    {
                        //LEFT
                        this.Position = Position.Left;
                        break;
                    }

                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                case 12:
                    {
                        //CENTER
                        this.Position = Position.Center;
                        break;
                    }

                case 13:
                case 14:
                case 15:
                case 16:
                case 17:
                case 18:
                    {
                        //RIGHT
                        this.Position = Position.Right;
                        break;
                    }
            }
        }

        private void GetHeight()
        {
            Random rnd = new Random();
            int dice = rnd.Next(1, 18);

            switch (dice)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                    {
                        //High
                        this.Height = PenaltyApp.Height.High;
                        break;
                    }

                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                case 16:
                case 17:
                case 18:
                    {
                        //Low
                        this.Height = PenaltyApp.Height.Low;
                        break;
                    }
            }
        }
        private void GetDirection()
        {
            Random rnd = new Random();
            int dice = rnd.Next(1, 18);

            switch (dice)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                    {
                        //LEFT
                        this.Direction = Direction.LookLeft;
                        break;
                    }

                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                case 12:
                    {
                        //CENTER
                        this.Direction = Direction.LookCentral;
                        break;
                    }

                case 13:
                case 14:
                case 15:
                case 16:
                case 17:
                case 18:
                    {
                        //RIGHT
                        this.Direction = Direction.LookRight;
                        break;
                    }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
