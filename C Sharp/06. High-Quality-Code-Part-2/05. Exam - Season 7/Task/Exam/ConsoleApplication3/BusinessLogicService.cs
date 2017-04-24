namespace ConsoleApplication3
{
    // I am not sure if we need this, but too scared to delete. 
     class BusinessLogicService
    {
        public void Execute(ConsoleReaderProvider read)
        {
            var engine = new Engine(read);

            engine.Start();
        }
    }
}
