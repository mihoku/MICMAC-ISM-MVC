using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MICMAC_ISM_MVC.Data;
using MICMAC_ISM_MVC.Models;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Authorization;

namespace MICMAC_ISM_MVC.Controllers
{
    [Authorize]
    public class FeaturesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FeaturesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Features
        public async Task<IActionResult> Index(int id)
        {
            var applicationDbContext = _context.Features.Include(f => f.ProjectIdentity)
                .Where(m => m.ProjectID == id);
            ViewData["ProjectID"] = id;
            ViewData["Project"] = _context.ProjectIdentitiy.Find(id).Title;
            return View(await applicationDbContext.ToListAsync());
        }

        public IActionResult CreateInteraction(int id, int id2)
        {
            ViewData["featureAID"] = id;
            ViewData["featureBID"] = id2;
            var featureA = _context.Features.Find(id);
            var featureB = _context.Features.Find(id2);
            ViewData["Title"] = "Set interactions between " + featureA.Code + " and " + featureB.Code;
            //ViewData["Subtitle"] = featureA.ProjectIdentity.Title;
            List <String> interaction = new List<String>() { "V", "A", "X", "O" };
            ViewData["ProjectID"] = featureA.ProjectID;
            ViewData["ExistingStatus"] = _context.StructuralSelfInteractions.Where(y => y.FeatureAID == id && y.FeatureBID == id2).Count() != 0;
            if (_context.StructuralSelfInteractions.Where(y => y.FeatureAID==id&&y.FeatureBID == id2).Count() != 0)
            {
                var existing = _context.StructuralSelfInteractions.Where(y => y.FeatureAID == id && y.FeatureBID == id2).First();
                //ViewData["SelectedInteraction"] = existing.InteractionType;
                ViewData["SSIID"] = existing.ID;
                ViewData["InteractionType"] = new SelectList(interaction,existing.InteractionType);
                return View();
            }
            else
            {
                ViewData["SSIID"] = 1;
                var SelectedInteraction = "V";
                ViewData["InteractionType"] = new SelectList(interaction,SelectedInteraction);
                return View();
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateInteraction([Bind("ID,FeatureAID,FeatureBID,InteractionType")] StructuralSelfInteraction ssi)
        {
            //if (ModelState.IsValid)
            //{
            var f = _context.Features.Find(ssi.FeatureAID);
            if (ssi.InteractionType=="V"|| ssi.InteractionType == "A"|| ssi.InteractionType == "X"||ssi.InteractionType == "O")
            {
                if (_context.StructuralSelfInteractions.Where(y => y.FeatureAID == ssi.FeatureAID && y.FeatureBID == ssi.FeatureBID).Count() != 0)
                {
                    _context.StructuralSelfInteractions.Where(y => y.FeatureAID == ssi.FeatureAID && y.FeatureBID == ssi.FeatureBID).First().InteractionType = ssi.InteractionType;
                    _context.SaveChanges();
                    return RedirectToAction(nameof(SSI), new { id = f.ProjectID });
                }
                else
                {
                    ssi.ID = 0;
                    _context.StructuralSelfInteractions.Add(ssi);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(SSI), new { id = f.ProjectID });
                }
            }

            else
            {
                ViewData["featureAID"] = ssi.FeatureAID;
                ViewData["featureBID"] = ssi.FeatureBID;
                List<String> interaction = new List<String>() { "V", "A", "X", "O" };
                ViewData["InteractionType"] = new SelectList(interaction);
                return View(ssi);
            }

        }

        // GET: Features
        public async Task<IActionResult> SSI(int id)
        {
            var applicationDbContext = _context.Features.Include(f => f.ProjectIdentity).Include(y=>y.SSI)
                .Where(m => m.ProjectID == id);
            ViewData["ProjectID"] = id;
            ViewData["Project"] = _context.ProjectIdentitiy.Find(id).Title;
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> IRM(int id)
        {
            var applicationDbContext = _context.Features.Include(f => f.ProjectIdentity).Include(y => y.IRM)
                .Where(m => m.ProjectID == id);
            ViewData["status"] = _context.InitialReachabilityMatrix.Where(y => y.FeatureA.ProjectID == id).Count()!=0;
            ViewData["ProjectID"] = id;
            ViewData["Project"] = _context.ProjectIdentitiy.Find(id).Title;
            return View(await applicationDbContext.ToListAsync());
        }

        public IActionResult GenerateIRM(int id)
        {
            List<InitialReachabilityMatrix> data = new List<InitialReachabilityMatrix>();
            var features = _context.Features.Where(y => y.ProjectID == id).ToList();
            var applicationDbContext = _context.StructuralSelfInteractions.Where(y=>y.FeatureA.ProjectID == id).ToList();
            foreach(var x in features)
            {
                var testcount = applicationDbContext.Where(y => y.FeatureAID == x.ID).Count() + applicationDbContext.Where(y => y.FeatureBID == x.ID).Count();
                if (testcount != features.Count() - 1)
                {
                    return RedirectToAction(nameof(IRM), new { id = id });
                }
                else
                {
                    testcount = testcount;
                }
            }
            foreach (var matrix in applicationDbContext)
            {
                if (matrix.InteractionType == "V")
                {
                    InitialReachabilityMatrix datapoint_1 = new InitialReachabilityMatrix()
                    {
                        FeatureAID = matrix.FeatureAID,
                        FeatureBID = matrix.FeatureBID,
                        IRM = 1
                    };
                    data.Add(datapoint_1);

                    InitialReachabilityMatrix datapoint_2 = new InitialReachabilityMatrix()
                    {
                        FeatureAID = matrix.FeatureBID,
                        FeatureBID = matrix.FeatureAID,
                        IRM = 0
                    };
                    data.Add(datapoint_2);
                }
                else if (matrix.InteractionType == "A")
                {
                    InitialReachabilityMatrix datapoint_1 = new InitialReachabilityMatrix()
                    {
                        FeatureAID = matrix.FeatureAID,
                        FeatureBID = matrix.FeatureBID,
                        IRM = 0
                    };
                    data.Add(datapoint_1);

                    InitialReachabilityMatrix datapoint_2 = new InitialReachabilityMatrix()
                    {
                        FeatureAID = matrix.FeatureBID,
                        FeatureBID = matrix.FeatureAID,
                        IRM = 1
                    };
                    data.Add(datapoint_2);
                }
                else if (matrix.InteractionType == "O")
                {
                    InitialReachabilityMatrix datapoint_1 = new InitialReachabilityMatrix()
                    {
                        FeatureAID = matrix.FeatureAID,
                        FeatureBID = matrix.FeatureBID,
                        IRM = 0
                    };
                    data.Add(datapoint_1);

                    InitialReachabilityMatrix datapoint_2 = new InitialReachabilityMatrix()
                    {
                        FeatureAID = matrix.FeatureBID,
                        FeatureBID = matrix.FeatureAID,
                        IRM = 0
                    };
                    data.Add(datapoint_2);
                }
                else if (matrix.InteractionType == "X")
                {
                    InitialReachabilityMatrix datapoint_1 = new InitialReachabilityMatrix()
                    {
                        FeatureAID = matrix.FeatureAID,
                        FeatureBID = matrix.FeatureBID,
                        IRM = 1
                    };
                    data.Add(datapoint_1);

                    InitialReachabilityMatrix datapoint_2 = new InitialReachabilityMatrix()
                    {
                        FeatureAID = matrix.FeatureBID,
                        FeatureBID = matrix.FeatureAID,
                        IRM = 1
                    };
                    data.Add(datapoint_2);
                }
                else
                {
                    var test = 0;
                }
            }
            foreach(var item in features)
            {
                InitialReachabilityMatrix datapoint_1 = new InitialReachabilityMatrix()
                {
                    FeatureAID = item.ID,
                    FeatureBID = item.ID,
                    IRM = 1
                };
                data.Add(datapoint_1);
            }
            _context.InitialReachabilityMatrix.AddRange(data);
            _context.SaveChanges();
            return RedirectToAction(nameof(IRM), new { id=id });
        }

        public async Task<IActionResult> FRM(int id)
        {
            var applicationDbContext = _context.Features.Include(f => f.ProjectIdentity).Include(y => y.FRM).Include(y => y.TN).Include(y=>y.Coordinate)
                .Where(m => m.ProjectID == id);
            ViewData["status"] = _context.FinalReachabilityMatrix.Where(y => y.FeatureA.ProjectID == id).Count() != 0;
            ViewData["ProjectID"] = id;
            ViewData["Project"] = _context.ProjectIdentitiy.Find(id).Title;
            ViewData["VariableCount"] = applicationDbContext.Count();
            var text = "";
            var coordinates = _context.MICMACCoordinate.Where(y => y.Feature.ProjectID == id).Include(y=>y.Feature).ToList();
            foreach (var item in coordinates.GroupBy(y => new { y.Dependence, y.DrivingPower })
                .Select(g => new { Dependence=g.Key.Dependence, DrivingPower=g.Key.DrivingPower, Codes = string.Join(",", g.Select(i => i.Feature.Code)) }))
            {
                text += "{variable:'"+ item.Codes +"', x:" + item.Dependence.ToString() + ", value:" + item.DrivingPower.ToString() + "},\n";
            }
            ViewData["QuadrantData"] = text;
            return View(await applicationDbContext.ToListAsync());
        }

        public IActionResult GenerateFRM(int id)
        {
            List<FinalReachabilityMatrix> data = new List<FinalReachabilityMatrix>();
            List<TransitivityNotes> transitivity_notes = new List<TransitivityNotes>();
            var features = _context.Features.Where(y => y.ProjectID == id).ToList();
            var applicationDbContext = _context.InitialReachabilityMatrix.Where(y => y.FeatureA.ProjectID == id).ToList();
            
            foreach (var matrix in applicationDbContext)
            {
                FinalReachabilityMatrix datapoint_1 = new FinalReachabilityMatrix()
                {
                    FeatureAID = matrix.FeatureAID,
                    FeatureBID = matrix.FeatureBID,
                    FRM = matrix.IRM,
                    AddingTransitivity = false
                };
                data.Add(datapoint_1);
            }
            _context.FinalReachabilityMatrix.AddRange(data);
            _context.SaveChanges();

            foreach(var item in features)
            {
                foreach(var irm in item.IRM.Where(y=>y.IRM==1))
                {
                    if(_context.InitialReachabilityMatrix.Where(y => y.FeatureAID == irm.FeatureBID && y.IRM == 1).Count() != 0)
                    {
                        var confirm = _context.InitialReachabilityMatrix.Where(y => y.FeatureAID == irm.FeatureBID && y.IRM == 1).ToList();
                        foreach (var t in confirm)
                        {
                            if(_context.FinalReachabilityMatrix.Where(y => y.FeatureAID == item.ID && y.FeatureBID == t.FeatureBID).Count() != 0)
                            {
                                var reconfirm = _context.FinalReachabilityMatrix.Where(y => y.FeatureAID == item.ID && y.FeatureBID == t.FeatureBID).First();
                                if (reconfirm.FRM != 1)
                                {
                                    reconfirm.FRM = 1;
                                    reconfirm.AddingTransitivity = true;
                                    _context.SaveChanges();
                                    TransitivityNotes tn = new TransitivityNotes()
                                    {
                                        FeatureAID = item.ID,
                                        FeatureBID = irm.FeatureBID,
                                        FeatureCID = t.FeatureBID,
                                        FRMID = reconfirm.ID,
                                    };
                                    transitivity_notes.Add(tn);
                                }
                                else { var seed = 0; }
                            }
                        }
                    }
                }
            }

            _context.TransitivityNotes.AddRange(transitivity_notes);
            _context.SaveChanges();

            List<MICMACCoordinate> coordinates = new List<MICMACCoordinate>();

            foreach(var v in features)
            {
                MICMACCoordinate coordinate_data = new MICMACCoordinate()
                {
                    FeatureID = v.ID,
                    Dependence = _context.FinalReachabilityMatrix.Where(y => y.FeatureBID == v.ID).Sum(y => y.FRM),
                    DrivingPower = _context.FinalReachabilityMatrix.Where(y => y.FeatureAID == v.ID).Sum(y => y.FRM)
                };
                coordinates.Add(coordinate_data);
            }

            _context.MICMACCoordinate.AddRange(coordinates);
            _context.SaveChanges();

            return RedirectToAction(nameof(FRM), new { id = id });
        }

        public IActionResult Partition(int id)
        {
            var applicationDbContext = _context.PartitionFeatureSet.Include(f => f.Partition).Include(f => f.Feature).Include(f => f.PartitionAntecedentSets).Include(f => f.PartitionIntersectionSets).Include(f => f.PartitionReachabilitySets)
                .Where(m => m.Partition.ProjectID == id);
            ViewData["status"] = _context.Partition.Where(y => y.ProjectID == id).Count() != 0;
            ViewData["ProjectID"] = id;
            ViewData["Project"] = _context.ProjectIdentitiy.Find(id).Title;
            return View(applicationDbContext.ToList());
        }

        public IActionResult ExecutePartition(int id)
        {
            var iteration_seed = 1;
            var flag_seed = _context.Features.Where(y => y.ProjectID == id).Count();
            var feature_list = _context.Features.Where(y => y.ProjectID == id).ToList();
            List<int> selected_features = new List<int>();

            while (flag_seed > 0)
            {
                Partition partition_data = new Partition()
                {
                    Iteration = iteration_seed,
                    ProjectID = id
                };
                _context.Partition.Add(partition_data);
                _context.SaveChanges();

                List<int> selected_features_ = new List<int>();

                foreach (var item in feature_list.Where(y => y.PartitionFeatureSets.Where(y => y.SelectedLevel==true).Count() == 0))
                {
                    PartitionFeatureSet partition_feature_set = new PartitionFeatureSet()
                    {
                        PartitionID = partition_data.ID,
                        FeatureID = item.ID,
                        SelectedLevel = false
                    };
                    
                    var reachability_set = _context.FinalReachabilityMatrix.Where(x => x.FRM == 1 && x.FeatureAID == item.ID&&!selected_features.Contains(x.FeatureBID)).ToList();
                    var antecedent_set = _context.FinalReachabilityMatrix.Where(x => x.FRM == 1 && x.FeatureBID == item.ID && !selected_features.Contains(x.FeatureAID)).ToList();
                    var intersection_set = reachability_set.Where(y => antecedent_set.Where(x => x.FeatureAID == y.FeatureBID).Count() != 0).ToList();
                    if (intersection_set.Count()==reachability_set.Count())
                    {
                        partition_feature_set.SelectedLevel = true;
                    }

                    _context.PartitionFeatureSet.Add(partition_feature_set);
                    _context.SaveChanges();

                    List<PartitionReachabilitySet> partition_reachability_sets = new List<PartitionReachabilitySet>();


                    foreach (var rs in reachability_set)
                    {
                        PartitionReachabilitySet partition_reachability_ = new PartitionReachabilitySet()
                        {
                            FeatureID = rs.FeatureBID,
                            PartitionFeatureSetID = partition_feature_set.ID
                        };
                        partition_reachability_sets.Add(partition_reachability_);
                    }

                    List<PartitionAntecedentSet> partition_antecedent_sets = new List<PartitionAntecedentSet>();


                    foreach (var rs in antecedent_set)
                    {
                        PartitionAntecedentSet partition_antecedent_ = new PartitionAntecedentSet()
                        {
                            FeatureID = rs.FeatureAID,
                            PartitionFeatureSetID = partition_feature_set.ID
                        };
                        partition_antecedent_sets.Add(partition_antecedent_);
                    }

                    List<PartitionIntersectionSet> partition_intersection_sets = new List<PartitionIntersectionSet>();


                    foreach (var rs in intersection_set)
                    {
                        PartitionIntersectionSet partition_intersection_ = new PartitionIntersectionSet()
                        {
                            FeatureID = rs.FeatureBID,
                            PartitionFeatureSetID = partition_feature_set.ID
                        };
                        partition_intersection_sets.Add(partition_intersection_);
                    }

                    _context.PartitionReachabilitySet.AddRange(partition_reachability_sets);
                    _context.SaveChanges();
                    _context.PartitionAntecedentSet.AddRange(partition_antecedent_sets);
                    _context.SaveChanges();
                    _context.PartitionIntersectionSet.AddRange(partition_intersection_sets);
                    _context.SaveChanges();
                    if (intersection_set.Count() == reachability_set.Count())
                    {
                        selected_features_.Add(item.ID);
                    }
                }

                flag_seed -= partition_data.PartitionFeatureSets.Where(y => y.SelectedLevel==true).Count();
                iteration_seed += 1;
                selected_features.AddRange(selected_features_);
            }
            return RedirectToAction(nameof(Partition), new { id = id });
        }

        public IActionResult HierarchicalModel(int id)
        {
            var diagramObject = _context.PartitionFeatureSet.Where(y => y.Partition.ProjectID == id && y.SelectedLevel == true).Include(y => y.Partition).Include(y=>y.Feature).ToList();
            var text = "";
            ViewData["ProjectID"] = id;
            if (diagramObject.Count()!= 0)
            {
                ViewData["Project"] = _context.ProjectIdentitiy.Find(id).Title;
                var diagramObject_grouped = diagramObject.GroupBy(y => y.Partition.Iteration).ToList();
                var partition = "";
                foreach (var x in diagramObject_grouped.OrderByDescending(a => a.Key))
                {
                    var part = "P" + x.Key.ToString();

                    //partition.Add(part);
                    text += "subgraph " + part + "\n direction LR \n";
                    List<string> features = new List<string>();
                    foreach (var y in diagramObject.Where(t => t.Partition.Iteration == x.Key))
                    {
                        var s = y.Feature.Code + "[&quot;" + y.Feature.Code + " <hr/> " + y.Feature.VariableName.Replace(")", "").Replace("(", "") + "&quot;]";
                        features.Add(s);
                    }
                    text += string.Join(" <--> ", features.Select(i => i));
                    //if (x.Key != 1)
                    //{
                    //    text += " --> ";
                    //}
                    text += "\n end \n";
                    if (partition != "")
                    {
                        text += "\n" + partition + " --> " + part + "\n";
                    }
                    partition = part;
                }
                //text += string.Join(" --> ", partition.Select(i => i));
                ViewData["datapoints"] = text;
                return View();
            }
            else
            {
                text += "no-data";
                ViewData["datapoints"] = text;
                return View();
            }

        }
        
        public IActionResult ClearAnalysisData(int id, string source)
        {
            var pis_data = _context.PartitionIntersectionSet.Where(y => y.Feature.ProjectID == id).ToList();
            var pas_data = _context.PartitionAntecedentSet.Where(y => y.Feature.ProjectID == id).ToList();
            var prs_data = _context.PartitionReachabilitySet.Where(y => y.Feature.ProjectID == id).ToList();
            var pfs_data = _context.PartitionFeatureSet.Where(y => y.Feature.ProjectID == id).ToList();
            var part_data = _context.Partition.Where(y => y.ProjectID == id).ToList();
            var mc_data = _context.MICMACCoordinate.Where(y => y.Feature.ProjectID == id).ToList();
            var tn_data = _context.TransitivityNotes.Where(y => y.FeatureA.ProjectID == id).ToList();
            var frm_data = _context.FinalReachabilityMatrix.Where(y => y.FeatureA.ProjectID == id).ToList();
            var irm_data = _context.InitialReachabilityMatrix.Where(y => y.FeatureA.ProjectID == id).ToList();
            _context.PartitionIntersectionSet.RemoveRange(pis_data);
            _context.PartitionAntecedentSet.RemoveRange(pas_data);
            _context.PartitionReachabilitySet.RemoveRange(prs_data);
            _context.PartitionFeatureSet.RemoveRange(pfs_data);
            _context.Partition.RemoveRange(part_data);
            _context.MICMACCoordinate.RemoveRange(mc_data);
            _context.TransitivityNotes.RemoveRange(tn_data);
            _context.FinalReachabilityMatrix.RemoveRange(frm_data);
            _context.InitialReachabilityMatrix.RemoveRange(irm_data);
            _context.SaveChanges();
            if (source == "IRM")
            {
                return RedirectToAction(nameof(IRM), new { id = id });
            }
            else if (source == "FRM")
            {
                return RedirectToAction(nameof(FRM), new { id = id });
            }
            else if (source == "Partition")
            {
                return RedirectToAction(nameof(Partition), new { id = id });
            }
            else if (source == "HierarchicalModel")
            {
                return RedirectToAction(nameof(HierarchicalModel), new { id = id });
            }
            else
            {
                return RedirectToAction(nameof(SSI), new { id = id });
            }
        }

        //public IActionResult CalculateDependence(int id)
            //{

        //    return Content(dependence.ToString());
        //}

        // GET: Features/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Features == null)
            {
                return NotFound();
            }

            var features = await _context.Features
                .Include(f => f.ProjectIdentity)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (features == null)
            {
                return NotFound();
            }

            return View(features);
        }

        // GET: Features/Create
        public IActionResult Create(int id)
        {
            ViewData["ProjectID"] = id;
            return View();
        }

        // POST: Features/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Code,VariableName,Description,ProjectID")] Features features)
        {
            //if (ModelState.IsValid)
            //{
            features.ID = 0;
                _context.Add(features);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new {id=features.ProjectID });
            //}
            //ViewData["ProjectID"] = new SelectList(_context.ProjectIdentitiy, "ID", "ID", features.ProjectID);
            //return View(features);
        }

        // GET: Features/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Features == null)
            {
                return NotFound();
            }

            var features = await _context.Features.FindAsync(id);
            if (features == null)
            {
                return NotFound();
            }
            ViewData["ProjectID"] = features.ProjectID;
            return View(features);
        }

        // POST: Features/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Code,VariableName,Description,ProjectID")] Features features)
        {
            if (id != features.ID)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
                try
                {
                    _context.Update(features);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeaturesExists(features.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { id=features.ProjectID });
            //}
            //ViewData["ProjectID"] = new SelectList(_context.ProjectIdentitiy, "ID", "ID", features.ProjectID);
            //return View(features);
        }

        // GET: Features/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Features == null)
            {
                return NotFound();
            }

            var features = await _context.Features
                .Include(f => f.ProjectIdentity)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (features == null)
            {
                return NotFound();
            }

            return View(features);
        }

        // POST: Features/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Features == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Features'  is null.");
            }
            var features = await _context.Features.FindAsync(id);
            var project_id = features.ProjectID;
            if (features != null)
            {
                _context.Features.Remove(features);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { id=project_id });
        }

        private bool FeaturesExists(int id)
        {
          return (_context.Features?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
