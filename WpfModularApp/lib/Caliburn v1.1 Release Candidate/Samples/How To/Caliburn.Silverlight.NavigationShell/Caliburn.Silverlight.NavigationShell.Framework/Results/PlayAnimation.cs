namespace Caliburn.Silverlight.NavigationShell.Framework.Results
{
    using System;
    using System.Windows;
    using System.Windows.Media.Animation;
    using PresentationFramework;

    public class PlayAnimation : IResult 
    {
        private bool _wait;
        private readonly string _animationKey;

        public PlayAnimation(string animationKey)
        {
            _animationKey = animationKey;
        }

        public PlayAnimation Wait()
        {
            _wait = true;
            return this;
        }

        public void Execute(IRoutedMessageWithOutcome message, IInteractionNode handlingNode)
        {
            FrameworkElement element = null;

            if(handlingNode != null)
                element = handlingNode.UIElement as FrameworkElement;

            if (element == null && message != null)
                element = message.Source.UIElement as FrameworkElement;   

            if(element == null)
            {
                Completed(this, null);
                return;
            }

            var storyboard = (Storyboard)element.Resources[_animationKey];

            if (_wait)
                storyboard.Completed += delegate { Completed(this, null); };

            storyboard.Begin();

            if (!_wait)
                Completed(this, null);
        }

        public event Action<IResult, Exception> Completed = delegate { };
    }
}