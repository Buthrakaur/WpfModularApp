﻿namespace ContactManager.Presenters
{
    using System;
    using Caliburn.Core;
    using Caliburn.Core.Metadata;
    using Caliburn.PresentationFramework;
    using Caliburn.PresentationFramework.ApplicationModel;
    using Caliburn.Silverlight.ApplicationFramework;
    using Interfaces;
    using Microsoft.Practices.ServiceLocation;
    using Model;
    using Web;

    [PerRequest(typeof(IContactListPresenter))]
    [HistoryKey("Contacts")]
    public class ContactListPresenter : MultiPresenterManager, IContactListPresenter
    {
        private readonly IServiceLocator _serviceLocator;
        private readonly IShellPresenter _shellPresenter;
        private readonly BindableCollection<Contact> _contacts = new BindableCollection<Contact>();

        public ContactListPresenter(IServiceLocator serviceLocator, IShellPresenter shellPresenter)
        {
            _shellPresenter = shellPresenter;
            _serviceLocator = serviceLocator;
        }

        public BindableCollection<Contact> Contacts
        {
            get { return _contacts; }
        }

        public IResult LoadContacts()
        {
            return new WebServiceResult<ContactServiceClient, GetAllContactsCompletedEventArgs>(
                x => x.GetAllContactsAsync(),
                x => x.Result.Apply(dto => _contacts.Add(Map.ToContact(dto)))
                );
        }

        public void NewContact()
        {
            EditContact(new Contact {FirstName = "New", LastName = "Contact"});
        }

        public void EditContact(Contact contact)
        {
            var presenter = _serviceLocator.GetInstance<IContactDetailsPresenter>();
            presenter.Setup(this, contact);
            this.Open(presenter);
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            DisplayName = "Contact List";
        }

        protected override void ExecuteShutdownModel(ISubordinate model, Action completed)
        {
            var question = (Question)model;
            var dialogPresenter = _serviceLocator.GetInstance<IQuestionPresenter>();

            dialogPresenter.Setup(new[] {question}, completed);

            _shellPresenter.ShowDialog(dialogPresenter);
        }
    }
}