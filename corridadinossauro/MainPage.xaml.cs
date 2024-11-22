namespace corridadinossauro;

public partial class MainPage : ContentPage
{
	Player player;
	bool estaMorto = false;
	bool estaPulando = false;
	const int tempoEntreFrames = 25;
	int velocidade1 = 0;
	int velocidade2 = 0;
	int velocidade3 = 0;
	int velocidade = 0;
	int larguraJanela = 0;
	int alturaJanela = 0;
	const int forcaGravidade = 6;
	bool estaNoChao = true;
	bool estaNoAr = false;
	int tempoPulando = 0;
	int tempoNoAr = 0;
	const int forcaPulo = 8;
	const int maxTempoPulando = 6;
	const int maxTempoAr = 4;
	

    protected override void OnAppearing()
    {
        base.OnAppearing();
		Desenha();
    }

	void AplicaGravidade()
	{
		if(player.GetY()<0)
			player.MoveY(forcaGravidade);
			else if(player.GetY() >= 0)
			{
				player.SetY(0);
				estaNoChao = true;
				}
	}

	void AplicaPulo()
	{
		estaNoChao = false;
		if (estaPulando && tempoPulando >= maxTempoPulando)
		{
			estaPulando = false;
			estaNoAr = true;
			tempoNoAr = 0;
		}
		else if (estaNoAr && tempoNoAr >= maxTempoAr)
		{
			estaPulando = false;
			estaNoAr = false;
			tempoPulando = 0;
			tempoNoAr = 0;
		}	
		else if (estaPulando && tempoPulando < maxTempoPulando)
		{
			player.MoveY(-forcaPulo);
			tempoPulando++;
		}
		else if (estaNoAr)
		 tempoNoAr++;
	}


    protected override void OnSizeAllocated(double width, double height)
	{
		base.OnSizeAllocated(width, height);
		CorrigeTamanhoCenario(width, height);
		CalculaVelocidade(width);
	}

	void CalculaVelocidade(double width)
	{
		velocidade1 = (int)(width * 0.001);
		velocidade2 = (int)(width * 0.004);
		velocidade3 = (int)(width * 0.008);
		velocidade = (int)(width * 0.01);
	}

	void CorrigeTamanhoCenario(double width, double height)
	{
		foreach (var a in HSLayer1.Children)
			(a as Image).WidthRequest = width;
		foreach (var a in HSLayer2.Children)
			(a as Image).WidthRequest = width;
		foreach (var a in HSLayer3.Children)
			(a as Image).WidthRequest = width;
		foreach (var a in HSLayerChao.Children)
			(a as Image).WidthRequest = width;

		HSLayer1.WidthRequest = width;
		HSLayer2.WidthRequest = width;
		HSLayer3.WidthRequest = width;
		HSLayerChao.WidthRequest = width;

	}

	void GerenciaCenarios()
	{
		MoveCenario();
		GerenciaCenario(HSLayer1);
		GerenciaCenario(HSLayer2);
		GerenciaCenario(HSLayer3);
		GerenciaCenario(HSLayerChao);
	}

	void MoveCenario()
	{
		HSLayer1.TranslationX -= velocidade1;
		HSLayer1.TranslationX -= velocidade2;
		HSLayer1.TranslationX -= velocidade3;
		HSLayerChao.TranslationX -= velocidade;

	}

	void GerenciaCenario(HorizontalStackLayout HSL)
	{
		var view = (HSL.Children.First() as Image);
		if (view.WidthRequest + HSL.TranslationX < 0)
		{
			HSL.Children.Remove(view);
			HSL.Children.Add(view);
			HSL.TranslationX = view.TranslationX;
		}
	}

	async Task Desenha()
	{
		while (!estaMorto)
		{
			GerenciaCenarios();
			player.Desenha();
			await Task.Delay(tempoEntreFrames);
		}
	}
	public MainPage()
	{
		InitializeComponent();
		player=new Player(dog);
		player.Run();
	}

	void Pulo(object o, TappedEventArgs a)
	{
		if(estaNoChao)
		{
			estaPulando	= true;
		}
	}

	

}


