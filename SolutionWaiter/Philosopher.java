package SolutionWaiter;

public class Philosopher extends Thread {
    private final Table table;
    private final Waiter waiter;
    private final int id;
    private final int leftFork, rightFork;

    public Philosopher(int id, Table table, Waiter waiter) {
        this.id = id;
        this.table = table;
        this.waiter = waiter;
        this.rightFork = id;
        this.leftFork = (id + 1) % 5;
        start();
    }

    @Override
    public void run() {
        for (int i = 0; i < 10; i++) {
            System.out.println("Philosopher " + id + " is thinking " + (i + 1));

            waiter.requestPermission();

            table.getFork(rightFork);
            table.getFork(leftFork);

            System.out.println("Philosopher " + id + " is eating " + (i + 1));

            table.putFork(rightFork);
            table.putFork(leftFork);

            waiter.releasePermission();
        }
    }
}
