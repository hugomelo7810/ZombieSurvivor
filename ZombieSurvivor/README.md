# 🧟 ZombieSurvivor

Um jogo de sobrevivência em turnos, escrito em **C#**, onde o objetivo é sobreviver a **30 dias** em um apocalipse zumbi administrando fome, sede e vida.

## 🎯 Objetivo

Chegar vivo ao final dos 30 dias. O jogador morre se:
- A **vida** chegar a 0

## 🕹️ Como funciona

Cada rodada representa um dia. A cada dia, o jogador pode:

| Ação | Efeito |
|---|---|
| **Comer** | Consome um item de comida do inventário e recupera fome (pode ser feito no máximo 1x por dia) |
| **Beber** | Consome um item de bebida do inventário e recupera sede (pode ser feito no máximo 1x por dia) |
| **Fugir** | Passa o dia inteiro; fome e sede aumentam 7 pontos |
| **Explorar** | Passa o dia inteiro; gera de 1 a 3 eventos aleatórios |

> Comer e beber são ações livres (não avançam o dia sozinhas), mas **Fugir** e **Explorar** consomem o dia inteiro.

## 🎲 Eventos de exploração

Ao explorar, entre 1 e 3 eventos acontecem, sorteados com chance igual entre:

- **NothingFound** — nada acontece
- **Food** — encontra um item de comida aleatório (adicionado ao inventário)
- **Drink** — encontra um item de bebida aleatório (adicionado ao inventário)
- **MedicalKit** — recupera 15 pontos de vida
- **ZombieAttack** — perde 10 pontos de vida
- **AnimalBattle** — perde 6 pontos de vida

É possível o mesmo evento se repetir na mesma exploração (ex: encontrar dois kits médicos no mesmo dia).

## 🍎 Itens

### Comidas (`Foods`)
| Item | Efeito na fome |
|---|---|
| Fruit | -10 |
| Hamburguer | -20 |
| CornFlakes | -5 |
| Meat | -15 |
| Pasta | -15 |
| RottenMeat | +10 (piora a fome) |

### Bebidas (`Drinks`)
| Item | Efeito na sede |
|---|---|
| Water | -15 |
| Soda | -7 |
| Juice | -10 |
| Vodka | +10 (piora a sede) |

Comidas e bebidas só podem ser consumidas se estiverem no inventário — ou seja, precisam ser encontradas explorando antes de poderem ser usadas.

## 📊 Status do jogador

- **Vida (`life`)**: começa em 100, morte ao chegar em 0
- **Fome (`hunger`)**: começa em 0, varia entre 0 e 100
- **Sede (`thirst`)**: começa em 0, varia entre 0 e 100
- **Dia (`day`)**: começa em 1, meta chegar ao dia 30

Todos os valores são limitados entre 0 e 100 (clamp), nunca ultrapassando esses limites.

## 🛠️ Tecnologias

- **C#** / .NET (net10.0)
- Estrutura orientada a objetos, com toda a lógica encapsulada na classe `Game`
- **React** (front-end, planejado para o futuro)
- **PostgreSQL** (banco de dados, planejado para o futuro)

## 📂 Estrutura do código

- **Enums**: `Actions`, `ExplorationEvents`, `Foods`, `Drinks`
- **Métodos de sorteio**: `SortFood()`, `SortDrink()`, `SortEvent()`
- **Métodos de valor**: `HungerKiller(Foods)`, `ThirstKiller(Drinks)`
- **Ações do jogador**: `Eat(Foods)`, `Drink(Drinks)`, `RunAway()`, `Explore()`
- **Controle de jogo**: `CheckDeath()`, `NextDay()`

## 🚧 Status do projeto (em desenvolvimento)

- [x] Estrutura de variáveis e enums
- [x] Métodos de sorteio (`SortFood`, `SortDrink`, `SortEvent`)
- [x] Sistema de fome e sede (`Eat`, `Drink`, `RunAway`)
- [x] Verificação de morte (`CheckDeath`)
- [x] Avanço de dia (`NextDay`)
- [x] Sistema de exploração com múltiplos eventos (`Explore`)
- [ ] Integração do inventário nos eventos `Food` e `Drink` do `Explore()`
- [ ] Restrição de comer/beber apenas 1x por dia
- [ ] Menu principal e loop de jogo (`Play()`)
- [ ] Mensagem final de vitória/derrota

## ▶️ Como rodar

```bash
dotnet run
```

## 📝 Licença

Projeto pessoal de estudo, sem licença definida.