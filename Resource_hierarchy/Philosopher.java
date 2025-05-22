package Resource_hierarchy;

public class Philosopher extends Thread {
    private final Table table;
    private final int leftFork, rightFork;
    private final int id;

    public Philosopher(int id, Table table) {

        this.id = id;
        this.table = table;

        rightFork = id;
        leftFork = (id + 1) % 5;

        start();
    }

    @Override
    public void run() {
        for (int i = 0; i < 10; i++) {
            System.out.println("Philosopher" + id + " is thinking " + (i + 1) + " times");

            if (rightFork < leftFork) {
                table.getFork(rightFork);
                table.getFork(leftFork);
            } else {
                table.getFork(leftFork);
                table.getFork(rightFork);
            }
            System.out.println("Philosopher" + id + " is eating" + (i + 1) + " times");
            if (rightFork < leftFork) {
                table.putFork(leftFork);
                table.putFork(rightFork);
            } else {
                table.putFork(rightFork);
                table.putFork(leftFork);
            }
        }
    }
}