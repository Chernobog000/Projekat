using System.Reflection.Metadata;
using static ProdavnicaServis;

public class Racun
{
    public int Id { get; set; }
    public decimal Iznos { get; set; }
    // Ostala polja po potrebi
}

public class ProdavnicaServis
{
    private List<Racun> racuni;

    public ProdavnicaServis()
    {
        racuni = new List<Racun>();
        // Učitajte račune
    }

    public List<Racun> VratiRacuneJeftinijeOd(decimal iznos)
    {
        return racuni.Where(r => r.Iznos < iznos).ToList();
    }

    public List<Racun> VratiRacuneSkupljeOd(decimal iznos)
    {
        return racuni.Where(r => r.Iznos > iznos).ToList();
    }

    public Racun VratiRacunZaId(int id)
    {
        var racun = racuni.FirstOrDefault(r => r.Id == id);
        if (racun == null)
        {
            throw new Exception("NemaRacunaZaId");
        }
        return racun;
    }

    public Racun VratiNajskupljiRacun()
    {
        if (!racuni.Any())
        {
            throw new Exception("NemaNiJednogRacuna");
        }
        return racuni.OrderByDescending(r => r.Iznos).First();
    }

    public Racun VratiNajjeftinijiRacun()
    {
        if (!racuni.Any())
        {
            throw new Exception("NemaNiJednogRacuna");
        }
        return racuni.OrderBy(r => r.Iznos).First();
    }

    public decimal VratiProsecnuCenuSvihRacuna()
    {
        if (!racuni.Any())
        {
            throw new Exception("NemaNiJednogRacuna");
        }
        return racuni.Average(r => r.Iznos);
    }

public class ListaRacunaActivity extends AppCompatActivity
{

    private ListView listView;
private ArrayList<Racun> racuni;
@Override
    protected void onCreate(Bundle savedInstanceState)
{
    super.onCreate(savedInstanceState);
    setContentView(R.layout.activity_lista_racuna);

    listView = findViewById(R.id.listView);
    racuni = // Učitajte račune

    ArrayAdapter < Racun > adapter = new ArrayAdapter<>(this, android.R.layout.simple_list_item_1, racuni);
    listView.setAdapter(adapter);

    listView.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id)
    {
        Racun racun = racuni.get(position);
        Intent intent = new Intent(ListaRacunaActivity.this, RacunActivity.class);
intent.putExtra("racun", racun);
startActivity(intent);
            }
        });
    }

public class RacunActivity extends AppCompatActivity
{

    private TextView textView;
private Button backButton;

@Override
    protected void onCreate(Bundle savedInstanceState)
{
    super.onCreate(savedInstanceState);
    setContentView(R.layout.activity_racun);

    textView = findViewById(R.id.textView);
    backButton = findViewById(R.id.backButton);

    Racun racun = (Racun)getIntent().getSerializableExtra("racun");
    textView.setText(racun.toString());

    backButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v)
    {
        finish();
    }
});
    }
public class MainActivity extends AppCompatActivity{

    private Button sviRacuniButton;
    private Button jeftinijiRacuniButton;
    private Button skupljiRacuniButton;
    private Button najjeftinijiRacunButton;
    private Button najskupljiRacunButton;

@Override
    protected void onCreate(Bundle savedInstanceState)
{
    super.onCreate(savedInstanceState);
    setContentView(R.layout.activity_main);

    sviRacuniButton = findViewById(R.id.sviRacuniButton);
    jeftinijiRacuniButton = findViewById(R.id.jeftinijiRacuniButton);
    skupljiRacuniButton = findViewById(R.id.skupljiRacuniButton);
    najjeftinijiRacunButton = findViewById(R.id.najjeftinijiRacunButton);
    najskupljiRacunButton = findViewById(R.id.najskupljiRacunButton);

    sviRacuniButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v)
    {
        startActivity(new Intent(MainActivity.this, ListaRacunaActivity.class));
            }
        });

        
    }
}
