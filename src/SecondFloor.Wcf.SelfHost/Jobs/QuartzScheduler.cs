using Quartz;
using Quartz.Impl;
using Quartz.Impl.Triggers;

namespace SecondFloor.Wcf.SelfHost.Jobs
{
    public class QuartzScheduler
    {
        private ISchedulerFactory _schedFactory;
        private IScheduler _scheduler;
        private ITrigger _trigger;
        private IJobDetail _jobDetail;

        public QuartzScheduler()
        {
            _schedFactory = new StdSchedulerFactory();
            _scheduler = _schedFactory.GetScheduler();
            _scheduler.Start();
        }

        public void StartUp()
        {
            // caso queira geras o seu periodo vc pode usar http://www.cronmaker.com/   ou pela doc http://www.quartz-scheduler.net/documentation/quartz-2.x/tutorial/crontrigger.html
            // o schedulerPattern - Esta string define o perio de execução
            //string schedulerPattern = @"0 0 0 1/1 * ? *"; // todos os dias meia noite

            const string schedulerPattern = @"0/30 * * 1/1 * ? *"; // à cada 30 segundos

            _trigger = new CronTriggerImpl("triggerAnuncioCroon", "grpAnuncios", schedulerPattern);

            _jobDetail = new JobDetailImpl("anuncioJob", "jobs", typeof(JobPublicacao));
            
            _scheduler.ScheduleJob(_jobDetail, _trigger);
        }

        public void ShutDown()
        {
            _scheduler.Shutdown();
        }
    }
}