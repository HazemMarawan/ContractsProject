using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContractsProject.Models;
namespace ContractsProject.Controllers
{

    public class ContractController : Controller
    {
        public ContractsDB Obj = new ContractsDB();
        // GET: Contract
        public ActionResult Index()
        {
            List<Contract> contracts = Obj.Contracts.ToList();
            if (TempData["DeleteMsg"] != null)
                ViewBag.DeleteMsg = TempData["DeleteMsg"];
            return View(contracts);
        }
        [HttpGet]
        public ActionResult Add()
        {
    
            return View();
        }
        [HttpPost]
        public ActionResult Add(Contract contract,FormCollection form, HttpPostedFileBase[] nationalIdPhotos, HttpPostedFileBase[] contractTwoClients, HttpPostedFileBase[] commercialRegisterFiles, HttpPostedFileBase[] PieceDoc, HttpPostedFileBase[] CommitteeReport, HttpPostedFileBase[] ClientReply)
        {
           try
            { 
            string descArr = form["Desc"];
            List<string> descList = descArr.Split(',').ToList();
            string Fdan = form["Fdan"];
            List<string> fdanList = Fdan.Split(',').ToList();
            string Eirat = form["Eirat"];
            List<string> eiratList = Eirat.Split(',').ToList();
            string Sahm = form["Sahm"];
            List<string> sahmList = Sahm.Split(',').ToList();

            string Location = form["Location"];
            List<string> LocationList = Location.Split(',').ToList();
            string PieceNum = form["PieceNum"];
            List<string> PieceNumList = PieceNum.Split(',').ToList();
            //string PieceDoc = form["PieceDoc"];
            //List<string> PieceDocList = PieceDoc.Split(',').ToList();
            string HowOwn = form["HowOwn"];
            List<string> HowOwnList = HowOwn.Split(',').ToList();
            string DoumentNum = form["DoumentNum"];
            List<string> DoumentNumList = DoumentNum.Split(',').ToList();
            string Decision = form["Decision"];
            List<string> DecisionList = Decision.Split(',').ToList();
            List<PieceOfGround> pieceOfGrounds = new List<PieceOfGround>();
            PieceOfGround pieceOfGround = new PieceOfGround();
            string clientOne = form["clientOne"];
            List<string> clientOneList = clientOne.Split(',').ToList();
            string clientTwo = form["clientTwo"];
            List<string> clientTwoList = clientTwo.Split(',').ToList();

            for (int i=0;i< descList.Count;i++)
            {

                pieceOfGround = new PieceOfGround();
                pieceOfGround.Desc = descList[i];
                pieceOfGround.Eirat = Convert.ToInt32(eiratList[i]);
                pieceOfGround.Fdan = Convert.ToInt32(fdanList[i]);
                pieceOfGround.Sahm = Convert.ToInt32(sahmList[i]);

                pieceOfGround.Location = LocationList[i];
                pieceOfGround.PieceNum = PieceNumList[i];
                pieceOfGround.HowOwn = HowOwnList[i];
                pieceOfGround.Decision = DecisionList[i];
                pieceOfGround.DoumentNum = DoumentNumList[i];
                //pieceOfGround.PieceDoc = PieceDocList[i];
                HttpPostedFileBase PieceDocs = PieceDoc[i];
                HttpPostedFileBase CommitteeReports = CommitteeReport[i];
                HttpPostedFileBase ClientReplys = ClientReply[i];
                if (PieceDocs != null && CommitteeReports != null && ClientReplys != null)
                {
                    var InputFileName = Path.GetFileName(PieceDocs.FileName);
                    var ServerSavePath = Path.Combine(Server.MapPath("~/images/PieceOfGround/PieceDocs/") + InputFileName);
                    pieceOfGround.PieceDoc = "~/ images/PieceOfGround / PieceDocs / " + InputFileName;
                    PieceDocs.SaveAs(ServerSavePath);
                    //----------------
                    var InputFileNameCommitteeReports = Path.GetFileName(CommitteeReports.FileName);
                    var ServerSavePathCommitteeReports = Path.Combine(Server.MapPath("~/images/PieceOfGround/CommitteeReports/") + InputFileNameCommitteeReports);
                    pieceOfGround.CommitteeReport = "~/ images/PieceOfGround / CommitteeReports / " + InputFileNameCommitteeReports;
                    CommitteeReports.SaveAs(ServerSavePathCommitteeReports);
                    //-------------------
                    var InputFileNameClientReplys = Path.GetFileName(ClientReplys.FileName);
                    var ServerSavePathClientReplys = Path.Combine(Server.MapPath("~/images/PieceOfGround/ClientReplys/") + InputFileNameClientReplys);
                    pieceOfGround.ClientReplys = "~/ images/PieceOfGround / ClientReplys / " + InputFileNameClientReplys;
                    ClientReplys.SaveAs(ServerSavePathClientReplys);
                    //assigning file uploaded status to ViewBag for showing message to user.  
                    //ViewBag.UploadStatus = nationalIdPhotos.Count().ToString() + " files uploaded successfully.";
                }
                pieceOfGrounds.Add(pieceOfGround);
            }

            OwnerSequence ownerSequence = new OwnerSequence();
            List<OwnerSequence> ownerSequences = new List<OwnerSequence>();
            for (int i = 0; i < clientOneList.Count; i++)
            {
                ownerSequence = new OwnerSequence();
                ownerSequence.ClientOne = clientOneList[i];
                ownerSequence.ClientTwo = clientTwoList[i];
                HttpPostedFileBase file = contractTwoClients[i];
                if (file != null)
                {
                    
                    var InputFileName = Path.GetFileName(file.FileName);
                    var ServerSavePath = Path.Combine(Server.MapPath("~/images/OwnerSequencePhotos/") + InputFileName);
                    ownerSequence.OwnerSequencePhotoPath = "~/ images / OwnerSequencePhotos / " + InputFileName;
                    file.SaveAs(ServerSavePath);
                    //assigning file uploaded status to ViewBag for showing message to user.  
                    //ViewBag.UploadStatus = nationalIdPhotos.Count().ToString() + " files uploaded successfully.";
                }

                ownerSequences.Add(ownerSequence);
            }
            List<NationalIdPhoto> NationalIdPhotosList = new List<NationalIdPhoto>();
            NationalIdPhoto nationalIdPhoto = new NationalIdPhoto();
            foreach (HttpPostedFileBase file in nationalIdPhotos)
            {
             
                if (file != null)
                {
                    nationalIdPhoto = new NationalIdPhoto();
                    var InputFileName = Path.GetFileName(file.FileName);
                    var ServerSavePath = Path.Combine(Server.MapPath("~/images/NationalPhotos/") + InputFileName);
                    nationalIdPhoto.NationalIdPhotoPath = "~/ images / NationalPhotos / " + InputFileName;
                    NationalIdPhotosList.Add(nationalIdPhoto);
                    
                    file.SaveAs(ServerSavePath);
                    //assigning file uploaded status to ViewBag for showing message to user.  
                    //ViewBag.UploadStatus = nationalIdPhotos.Count().ToString() + " files uploaded successfully.";
                }

            }
            List<ComercialRegister> comercialRegistersList = new List<ComercialRegister>();
            ComercialRegister comercialRegister = new ComercialRegister();
            foreach (HttpPostedFileBase file in commercialRegisterFiles)
            {

                if (file != null)
                {
                    comercialRegister = new ComercialRegister();
                    var InputFileName = Path.GetFileName(file.FileName);
                    var ServerSavePath = Path.Combine(Server.MapPath("~/images/ComercialRegistersPhotos/") + InputFileName);
                    comercialRegister.ComercialRegisterPhotoPath = "~/ images / ComercialRegistersPhotos / " + InputFileName;
                    comercialRegistersList.Add(comercialRegister);

                    file.SaveAs(ServerSavePath);
                    //assigning file uploaded status to ViewBag for showing message to user.  
                    //ViewBag.UploadStatus = nationalIdPhotos.Count().ToString() + " files uploaded successfully.";
                }

            }



            contract.NationalIdPhotos = NationalIdPhotosList;
            contract.pieceOfGrounds = pieceOfGrounds;
            contract.OwnerSequences = ownerSequences;
            contract.ComercialRegisters = comercialRegistersList;

            Obj.Contracts.Add(contract);
            Obj.SaveChanges();

            return RedirectToAction("Index");

            }
            catch
            {
                ViewBag.AddError = "حدثت مشكله اثناء اضافه البيانات";
                return View(contract);
            }




        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Contract contract = Obj.Contracts.Where(s => s.contractId == id).FirstOrDefault();
            Obj.Contracts.Remove(contract);
            Obj.SaveChanges();
            TempData["DeleteMsg"] = "لقد تم مسح الملف";
            return RedirectToAction("Index");
        }
    }
}