// Povoar a tabela Apresentacao com dados iniciais 
using Exercicio13ASP.Models;

namespace Exercicio13ASP.Data
{
    public class DbInitializer
    {
        public static void Initialize(DbTurismoContext context)
        {
            //Garantir que o banco de dados foi criado
            context.Database.EnsureCreated();
            //Verificar se já existe dados na tabela Apresentacao
            if (!context.Apresentacao.Any())
            {
                Apresentacao apresentacao = new Apresentacao();
                apresentacao.Pagina = "Home";
                apresentacao.Texto = "<h1> Bem vindo! </h1><p> Esta é uma página onde pode pesquisar o" +
                  " local ideal para passar um fim-de-semana ou uma semana de férias em Portugal.</p><p>" +
                  " Obrigado pela preferência.</p>" +
                  "<div style='text-align:center'><img src='images/alentejo.jpg' class='rounded-circle z-depth-2'/></div>";


                context.Apresentacao.Add(apresentacao);

                context.SaveChanges();
            }
            if (!context.Segmentos.Any())
            {
                var Segmentos = new Segmentos[]
                {
                    new Segmentos { SegmentoNome = "Sol e Praia", Descricao = "Este tipo de turismo insere-se no Turismo de Lazer/descanso em destinos de praia." },
                    new Segmentos { SegmentoNome = "Cultural", Descricao = "Designa uma modalidade de turismo cuja motivação do deslocamento se dá com o objectivo de encontros artísticos, científicos, de formação e de informação." },
                    new Segmentos { SegmentoNome = "Natureza", Descricao = "É uma forma de turismo voltada para a apreciação de ecossistemas no seu estado natural, com a sua vida selvagem e a sua população nativa intactos." },
                    new Segmentos { SegmentoNome = "Urbano", Descricao = "Estas viagens são feitas a locais ou cidades de grande densidade populacional, sendo a duração destas viagens, em geral, curta." },
                    new Segmentos { SegmentoNome = "Tematico", Descricao = "Compreende deslocações a parques temáticos ou outro tipo de atracções relacionadas com divertimentos e experiências." },
                    new Segmentos { SegmentoNome = "Aventura", Descricao = "Este tipo de turismo é definido como a participação dos turistas em actividades que envolvem, geralmente, esforço físico." },
                    new Segmentos { SegmentoNome = "Religioso", Descricao = "Neste tipo de Turismo, as motivações são a fé, o culto e a visita a lugares directamente relacionados ou espirituais." },
                };

                context.Segmentos.AddRange(Segmentos);
                context.SaveChanges();
            }

            if (!context.Destinos.Any())
            {
                var destinos = new Destinos[]
                {
                    new Destinos { Nome = "Chaves e o Tâmega", SegmentosId = 2, Descricao = "Centro Histórico e Termas.", Regiao = "Norte/Interior" },
                    new Destinos { Nome = "Guimarães", SegmentosId = 2, Descricao = "A cidade berço da nacionalidade portuguesa e Património Mundial.", Regiao = "Norte" },
                    new Destinos { Nome = "O arquipélago dos Açores", SegmentosId = 3, Descricao = "Paisagens vitivinícolas da Ilha do Pico e centro historico de Angra do Heroísmo, ambos Património Mundial.", Regiao = "Ilhas" },
                    new Destinos { Nome = "Ilha da Madeira", SegmentosId = 4, Descricao = "A ilha da Madeira, com a sua floresta Laurissilva, classificada de Património da Humanidade pela UNESCO e Património Mundial, é um pólo de interesse turístico pelo seu clima ameno, pelas paisagens exuberantes e pela sua gastronomia.", Regiao = "Ilhas" },
                    new Destinos { Nome = "Porto a cidade Invicta", SegmentosId = 5, Descricao = "O Porto é uma cidade com um lugar de relevo no panorama cultural do País e da Europa, principalmente devido ao surgimento de cruzeiros no Rio Douro, e à popularização das visitas às caves de fermentação do Vinho do Porto. Foi Capital Europeia da Cultura em 2001. A Fundação de Serralves e a Casa da Música são dois pontos de visita obrigatória, assim como a Torre dos Clérigos (tornada ex-libris da cidade) e a Sé. De destacar ainda o Teatro Nacional S. João, os Jardins do Palácio de Cristal, a Ponte D. Luís e toda a zona do centro histórico, Património Mundial.", Regiao = "Norte" },
                    new Destinos { Nome = "As bonitas paisagens do interior de Portugal", SegmentosId = 2, Descricao = "As belas paisagens no seu interior, também atrai bastante turismo, em locais como na cidade de Silves, São Bartolomeu de Messines, Alcoutim, Monchique. A norte as gravuras paleolíticas ao longo do Rio Côa, Património Mundial.", Regiao = "Interior" },
                    new Destinos { Nome = "A Baixa de Lisboa, zona histórica da capital", SegmentosId = 4, Descricao = "Por seu lado, Lisboa, atrai turistas quer pela sua História, quer pela sua contemporaneidade, quer pelos seus monumentos (Aqueduto das Águas Livres, a Sé Catedral, a Baixa Pombalina, a Torre de Belém, o Mosteiro dos Jerónimos, Castelo de S. Jorge, o Oceanário de Lisboa). Capital Europeia da Cultura em 1994, acolheu a Exposição Mundial de 1998, e vários jogos do Euro 2004. Cidade rica em museus, Museu de Arte Antiga, Museu dos Coches, Museu do Azulejo, Património Mundial.", Regiao = "Sul" },
                    new Destinos { Nome = "Mira d'Air", SegmentosId = 2, Descricao = "As famosas grutas de Mira d'Aire.", Regiao = "Centro" },
                    new Destinos { Nome = "Serra da Estrela", SegmentosId = 5, Descricao = "As estancias de esqui na Serra da Estrela.", Regiao = "Centro" },
                    new Destinos { Nome = "As extensas planícies do Baixo Alentejo", SegmentosId = 2, Descricao = "Centro histórico de Évora e Templo de Diana, Património Mundial.  Vila Viçosa (Paço Ducal de Vila Viçosa, Castelo de Vila Viçosa, Santuário de Nossa Senhora da Conceição de Vila Viçosa e Centro Histórico.", Regiao = "Sul/Interior" },
                    new Destinos { Nome = "As praias de água límpida do Algarve", SegmentosId = 1, Descricao = "O Algarve, é um dos destinos turísticos preferidos dos europeus. O clima e a temperatura da água são os principais factores que contribuem para o grande crescimento do turismo nesta região. A maior densidade populacional e de turismo da região concentra-se na costa, mas os antepassados que preenchem uma rica história, assim como belas paisagens no seu interior, também atrai bastante turismo, em locais como na cidade de Silves, São Bartolomeu de Messines, Alcoutim, Monchique, entre outros.", Regiao = "Sul" },
                    new Destinos { Nome = "A Península de Setúbal", SegmentosId = 1, Descricao = "Tem das mais variadas características naturais e culturais destacando-se a Serra da Arrábida, a praia de Sesimbra, a Baía Natural do Seixal, as salinas de Alcochete, os Moinhos de Maré, as embarcações típicas do Rio Tejo e Rio Sado, as antigas vilas piscatórias e toda a fauna e flora ribeirinha, o Estuário do Sado e os seus Golfinhos.", Regiao = "Sul" },
                    new Destinos { Nome = "Alcobaça, Batalha, Tomar", SegmentosId = 2, Descricao = "Património Mundial", Regiao = "Centro" },
                    new Destinos { Nome = "Sintra", SegmentosId = 2, Descricao = "No século XIX, Sintra tornou-se o primeiro centro da arquitectura romântica da Europa. O rei Fernando II transformou um mosteiro em ruínas num castelo, onde a nova sensibilidade é visível no uso de elementos ao estilo gótico, egípcio, mourisco e renascença, e na criação de um parque com espécies de árvores locais e exóticas. Outros locais próximos de Sintra oferecem combinações únicas de parques e jardins que muito influenciaram a arquitectura paisagista europeia.", Regiao = "Sul" },
                    new Destinos { Nome = "Surf", SegmentosId = 6, Descricao = "Portugal é também um País onde se pratica, além de muitos outros desportos, o Surf. Entre as melhores praias para o desenvolvimento dessa prática desportiva estão Peniche, Ericeira, Cabedelo (Viana do Castelo), Aguçadoura (Póvoa de Varzim) e Canal das Barcas/ Malhão (Vila Nova de Milfontes).", Regiao = "Norte/CEntro/Sul" },
                    new Destinos { Nome = "Fátima", SegmentosId = 7, Descricao = "Em termos de turismo religioso, o ponto turístico mais atractivo é o Santuário de Nossa Senhora de Fátima.", Regiao = "Centro" },
                    new Destinos { Nome = "Braga", SegmentosId = 2, Descricao = "Sé de Braga, Santuário do Sameiro, Santuário do Bom Jesus do Monte e Falperra.", Regiao = "Norte" },
                    new Destinos { Nome = "Bragança", SegmentosId = 2, Descricao = "Centro Histórico, Castelo e Teatro Municipal.", Regiao = "Norte/Interior" },
                    new Destinos { Nome = "Aveiro", SegmentosId = 2, Descricao = "Arte Nova, Centro histórico com os seus canais fazendo lembrar Veneza, a Ria de Aveiro e a Reserva Natural das Dunas de São Jacinto", Regiao = "Norte" },
                    new Destinos { Nome = "Coimbra", SegmentosId = 2, Descricao = "Universidade, Judiaria e Portugal dos Pequeninos.", Regiao = "Centro" },
                    new Destinos { Nome = "Vila Real", SegmentosId = 2, Descricao = "Palácio de Mateus e Teatro Municipal.", Regiao = "Norte/Interior" },
                    new Destinos { Nome = "Elvas", SegmentosId = 2, Descricao = "Castelo de Elvas, Aqueduto da Amoreira, Forte de Santa Luzia, Centro Histórico de Elvas, Santuário do Senhor Jesus da Piedade e Sé de Elvas.", Regiao = "Sul/Interior" },
                    new Destinos { Nome = "Viana do Castelo", SegmentosId = 2, Descricao = "Palácio da Brejoeira, Igreja de Santa Luzia, Centro Histórico e romaria.", Regiao = "Norte" },
                    new Destinos { Nome = "Serras", SegmentosId = 6, Descricao = "A serra da Serra da Estrela, a serra do Gerês, Caramulo e Lousã, são também pontos muito procurados por quem se interessa por turismo rural, caminhadas e escaladas longe dos grandes centros.", Regiao = "Norte/Centro/Interior" },
                    new Destinos { Nome = "Albufeira", SegmentosId = 5, Descricao = "ZooMarine", Regiao = "Sul" },

                };
                context.Destinos.AddRange(destinos);
                context.SaveChanges();
            }
        }
    }
}



