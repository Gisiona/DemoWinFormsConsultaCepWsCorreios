namespace DemoWinFormsConsultaCepWsCorreios.Entidades
{
    public  class Endereco
    {
        public string id { get; set; }
        public string cep { get; set; }
        public string rua { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public string uf { get; set; }
        public string complemento { get; set; }


        public Endereco()
        {
        }

        public Endereco(string _id, string _cep, string _rua, string _bairro, string _cidade, string _estado, string _uf, string _complemento)
        {
            id = _id;
            cep = _cep;
            rua = _rua;
            bairro = _bairro;
            cidade = _cidade;
            estado = _estado;
            uf = _uf;
            complemento = _complemento;
        }

    }
}
