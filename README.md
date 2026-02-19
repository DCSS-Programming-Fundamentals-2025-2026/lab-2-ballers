# Lab 2: ballers + team-8
```
Учасники ballers:
  1) Рибаков Ігор
  2) Солопов Данило
```
```
Учасники team-8:
  1) Лук'яненко Дарʼя
  2) Кравченко Марина
```

## Хто QA / хто Core
```
QA - Рибаков Ігор
Core - Солопов Данило
```

## Як запустити тести
Щоб запустити всі Unit та Integration тести, відкрийте термінал у кореневій папці проєкту та виконайте команду:
`dotnet test`

## Як перевірити: List через enumerator, Sort default, Sort альтернативне

### Логіка:
1) Логіка **IEnumerable** знаходиться в класі репозиторію (`lab1_ballers/Domain/CardsRepos/CardRepository.cs`).
2) Логіка **IEnumerator** знаходиться в класі `CardEnumerator` (`lab1_ballers/Upgrade/CardEnumerator.cs`).
3) Логіка **IComparer** знаходиться в класі `CardComparer` (`lab1_ballers/Upgrade/CardComparer.cs`).
4) Логіка **IComparable** (якщо реалізована) знаходиться в базовому класі `CardBase` (`lab1_ballers/Domain/Cards/CardBase.cs`).

### Виконання:
> Перед тим як виконувати будь-яку з нижче перерахованих дій, потрібно створити хоча б кілька карток (пункт `2) Create a Quiz Card` у головному меню).

**List через enumerator** - викликається через 6 пункт у меню:
`6) Test Enumerator`

**Sort default** - викликається через 7 пункт у меню:
`7) Natural Sort`

**Sort альтернативне** - викликається через 8 пункт у меню:
`8) Alternative Sort`

:shipit:
