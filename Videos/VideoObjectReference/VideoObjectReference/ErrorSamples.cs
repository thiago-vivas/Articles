using System;
using System.Collections.Generic;
using System.Text;

namespace VideoObjectReference
{
    public class ErrorSamples
    {
        SampleObj sampleObj;
        SampleChildObj sampleChild;
        List<string> lstSample;
        int? nullInt;

        private readonly SampleObj sampleinjectedObj;
        public ErrorSamples(SampleObj sampleInjectedObj)
        {
            this.sampleinjectedObj = sampleInjectedObj;


            var nullObject = new SampleObj();

            if (nullObject != null)
            {
                //does something
                var item = nullObject.Item1;
            }
        }

        public void Run()
        {
            try
            {
                this.NewObject();
            }
            catch (Exception)
            {

                throw;
            }
            try
            {
                this.ObjectInsideObject();
            }
            catch (Exception)
            {

                throw;
            }
            try
            {
                this.AddInNullList();
            }
            catch (Exception)
            {

                throw;
            }
            try
            {
                this.NullableObject();
            }
            catch (Exception)
            {

                throw;
            }
            try
            {
                this.DependencyInjection();
            }
            catch (Exception)
            {

                throw;
            }
        }
        private string NewObject()
        {
            return sampleChild.Item2;

            //fix
            return sampleChild?.Item2;

            //exemplo com esse metodo sendo chamado após um IF que chama dos outros metodos
            //um desses outros metodos instancia o sampleChild e o outro não
        }

        private int NullableObject()
        {
            return nullInt.Value;

            //fix
            return nullInt.HasValue ? nullInt.Value : 0;
            //esse fix também pode ser feito da forma de retornar um null, alterando a assinatura do metodo
        }
        private string ObjectInsideObject()
        {
            sampleObj = new SampleObj();
            return sampleObj.ChildObj.Item2;
            //fix
            return sampleObj.ChildObj?.Item2;
            //or instantiate the child object in the main object constructor
        }
        private void AddInNullList()
        {
            lstSample.Add("error");
            //fix
            //instantiate de list on obj creation
            //or validate if the list is null
            //or instantiate the list in obj constructor
        }
        private string DependencyInjection()
        {
            return sampleinjectedObj.Item1;

            //fix

            //return sampleinjectedObj?.Item1;
            //or
            //if no construtor ?? throw new ArgumentNullException(nameof(logger));
        }
    }
}
