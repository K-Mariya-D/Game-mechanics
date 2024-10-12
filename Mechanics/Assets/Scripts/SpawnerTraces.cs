using UnityEngine;

public class SpawnerTraces : Spawner
{
    /// <summary>
    /// ���, ��� ��������� �����
    /// </summary>
    [SerializeField] private IMoving _leavesTraces;
    public IMoving LeavesTraces
    {
        get => _leavesTraces;
        private set => _leavesTraces = value;
    }
    public override void Start()
    {
        base.Start();
        LeavesTraces = GameObject.FindWithTag("Player").GetComponent<Player>();
    }
    public override void Update()
    {
        SpawnEntity(LeavesTraces.Trans.position, Quaternion.identity);
        RemoveEntity();
    }
    /// <summary>
    /// ������� �������� � ��������� � � �������
    /// </summary>
    public override void SpawnEntity(Vector3 position, Quaternion rotation)
    {
        TimeToNextSpawn -= Time.deltaTime;
        if (LeavesTraces.IsMoving && TimeToNextSpawn <= 0f)
        {
            QueueEntity.Enqueue(Instantiate(Entity, position, rotation));
            TimeToNextSpawn = Frequency;
        }
    }
    /// <summary>
    /// ���������� �������� �� �������
    /// </summary>
    public override void RemoveEntity()
    {
        if (QueueEntity.Count > MaxSpawnCount)
            DestroyImmediate(QueueEntity.Dequeue());
    }
}
