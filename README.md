# ResearchTree
[![CI/CD](https://github.com/samsmithnz/ResearchTree/actions/workflows/workflow.yml/badge.svg)](https://github.com/samsmithnz/ResearchTree/actions/workflows/workflow.yml)

```mermaid
graph LR;
  Start;
  IfWorkersAssigned
  DoWork
  FindNewResearch
  End;
  Start-->IfWorkersAssigned;
  IfWorkersAssigned-->DoWork;
  DoWork-->DoWork
  DoWork-->FindNewResearch;
  FindNewResearch-->End;
```



![image](https://user-images.githubusercontent.com/8389039/153774354-a8dbf3ec-5a33-4e79-81b9-f4f1bcdcdaea.png)

```mermaid
graph LR;
    A-->B;
    A-->C;
    B-->D;
    C-->D;
    D-->E;
    D-->F-->G;
```

